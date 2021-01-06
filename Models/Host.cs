using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;
using VNM2020.Services;

namespace VNM2020.Models
{
    public class Host : ObservableObject
    {
        public int HostId { get; set; }
        public int CategoryId { get; set; }       

        private string name;        
        public string Name { get => name; set => Set(ref name, value); }

        public string address; 
        public string Address { get => address; set => Set(ref address, value); }

        public string mac;
        public string Mac { get => mac; set => Set(ref mac, value); }

        public string notes;
        public string Notes { get => notes; set => Set(ref notes, value); }

        public string mailAddress;
        public string MailAddress { get => mailAddress; set => Set(ref mailAddress, value); }


        [NotMapped]
        public ObservableCollection<Action> actions=new ObservableCollection<Action>();
        [NotMapped]
        public ObservableCollection<Action> Actions { get => actions; set => Set(ref actions, value); }

        public string status = "New Host";
        public string Status { get => status; set { Set(ref status, value); } }

        public int fatherId;      
        public int FatherId { get => fatherId; set => Set(ref fatherId, value); }

        public Host father;
        [NotMapped]
        public Host Father
        {
            get => father; set
            {
                Set(ref father, value);
                if (value != null)
                {
                    FatherId = value.HostId;
                }

            }
        }

        public int timecounter=0;
        [NotMapped]
        public int Timecounter { get => timecounter; set => Set(ref timecounter, value); }

        public int timertick = 0;
        [NotMapped]
        public int Timertick { get => timertick; set => Set(ref timertick, value); }

        public int seconds = 0;       
        public int Seconds
        {
            get => seconds;
            set
            {
                Timecounter = value;
                Timertick = 0;
                Set(ref seconds, value);
                if (value == 0)
                {
                    Status = "Paused";
                }
                else
                {
                    Status = "Hold";
                }

            }
        }

        public double rownumber = 0;      
        public double Rownumber
        {
            get => rownumber;
            set
            {
                Set(ref rownumber, value);             
            }
        }

        public double colnumber = 0;      
        public double Colnumber
        {
            get => colnumber; set
            {
                Set(ref colnumber, value);               
            }
        }

        public double scale = 0;        
        public double Scale { get => scale; set => Set(ref scale, value); }

        public bool selection = false;
        [NotMapped]
        public bool Selection { get => selection; set { 
                Set(ref selection, value);
                if (value)
                {
                    HostVisibility = Visibility.Visible;
                }
                else
                {
                    HostVisibility = Visibility.Collapsed;
                }
            } }

        public Visibility hostVisibility = Visibility.Collapsed;
        [NotMapped]
        public Visibility HostVisibility { get => hostVisibility; set => Set(ref hostVisibility, value); }

        [NotMapped]
        public int counter = 0;

        public bool mailable = true;        
        public bool Mailable { get => mailable; set => Set(ref mailable, value); }

        public string lastUp;
        public string LastUp { get => lastUp; set => Set(ref lastUp, value); }

        public string lastDown;
        public string LastDown { get => lastDown; set => Set(ref lastDown, value); }

        async public void SetRate()
        {
            await Task.Run(() =>
            {               
                for (int i = 0; i < Actions.Count; i++)
                {                    
                    Actions[i].Count = i + 1;
                    Actions[i].Reply = (Actions[i].Time / 2)+5;
                    if (i > 0)
                    {                      
                            Actions[i].PrevReply = Actions[i-1].Reply;
                            Actions[i].PrevCount = Actions[i - 1].Count;
                    }
                }

            });
            RaisePropertyChanged("Actions");
        }

        async public Task GetNameOverIp()
        {
            try
            {
                IPHostEntry hostEntry = await Dns.GetHostEntryAsync(Address);
                NotificationService.AddtoLog("Done", this.Name, $"Host is known as {hostEntry.HostName} on DNS");
                Name = hostEntry.HostName;
            }
            catch (Exception e)
            {
                NotificationService.AddtoLog("Exception", this.Name, e.Message);
            }
        }

        public async void Tick(bool manualping = false)
        {
            if (Seconds != 0 || manualping)
            {
                if (!manualping)
                {
                    Timecounter--;
                    Timertick++;
                }
                
                if (Timertick == Seconds || manualping)
                {
                    if (!manualping)
                    {
                        Timertick = 0;
                        Timecounter = Seconds;
                    }
                    
                    try
                    {
                        Ping ping = new Ping();
                        PingReply pingReply = null;
                        pingReply = await ping.SendPingAsync(Address, 5);                         
                        Action action = new Action(DateTime.Now, pingReply.Status.ToString(), pingReply.RoundtripTime, HostId);                        
                        Core.Instance.AddAction(action, HostId);

                        if (pingReply.Status.ToString() == "Success")
                        {
                            bool notify = false;
                            if (Status =="Error")
                            {
                                notify = true;
                            }
                            Status = "Ok";
                            LastUp = action.ToolTip;
                            counter = 0;
                            if (notify)
                            {                               
                                NotificationService.AddtoLog("Online", this.Name, "Back online!");
                                if (Mailable && GlobalSettings.Instance.EnableNotifications)
                                {
                                    await Task.Run(() =>
                                    {
                                        string actionBody = "";
                                        actionBody += $"Name: {Name}" + "\n";
                                        actionBody += $"Address: {Address}" + "\n";
                                        actionBody += $"Physical: {Mac}" + "\n";
                                        actionBody += $"Notes: {Notes}" + "\n";
                                        actionBody += $"Update Delay: {Seconds}" + "\n";                                        
                                        actionBody += $"Last Up: {LastUp}" + "\n";
                                        actionBody += $"Last Down: {LastDown}" + "\n";
                                        if (Father != null)
                                        {
                                            actionBody += $"Parent: {Father.Name}" + "\n";
                                            actionBody += $"Parent Address: {Father.Address}" + "\n";
                                            actionBody += $"Parent Status: {Father.Status}" + "\n";
                                            actionBody += $"Parent Last Up: {Father.LastUp}" + "\n";
                                            actionBody += $"Parent Last Down: {Father.LastDown}" + "\n";
                                        }
                                        else
                                        {
                                            actionBody += $"No Parent Host Noted" + "\n";
                                        }

                                        NotificationService.SendMail($"{DateTime.Now} {Name} : {Address} is back online", actionBody, MailAddress);
                                    });
                                }

                            }                            
                        }

                        if (pingReply.Status.ToString() != "Success" && counter < 3)
                        {
                            counter++;
                            Status = "Hold";
                        }

                        else if (counter == 3)
                        {
                            bool notify = false;
                            if (Status != "Error")
                            {
                                notify = true;
                            }
                            Status = "Error";
                            LastDown = action.ToolTip;
                            counter = 4;

                            if (notify && Mailable &&  GlobalSettings.Instance.EnableNotifications)
                            {                               
                                NotificationService.AddtoLog("Offline", this.Name, "Host has left the party!");
                                await Task.Run(() =>
                                {
                                    string actionBody = "";
                                    actionBody += $"Name: {Name}" + "\n";
                                    actionBody += $"Address: {Address}" + "\n";
                                    actionBody += $"Physical: {Mac}" + "\n";
                                    actionBody += $"Notes: {Notes}" + "\n";
                                    actionBody += $"Update Delay: {Seconds}" + "\n";                                  
                                    actionBody += $"Last Up: {LastUp}" + "\n";
                                    actionBody += $"Last Down: {LastDown}" + "\n";
                                    if (Father!=null)
                                    {
                                        actionBody += $"Parent: {Father.Name}" + "\n";
                                        actionBody += $"Parent Address: {Father.Address}" + "\n";
                                        actionBody += $"Parent Status: {Father.Status}" + "\n";
                                        actionBody += $"Parent Last Up: {Father.LastUp}" + "\n";
                                        actionBody += $"Parent Last Down: {Father.LastDown}" + "\n";
                                    }
                                    else
                                    {
                                        actionBody += $"No Parent Host Noted" + "\n";
                                    }
                                    
                                    NotificationService.SendMail($"{DateTime.Now} {Name} : {Address} is offline", actionBody, MailAddress);
                                });
                            }
                            
                        }

                        if (Selection)
                            Core.Instance.GetActions(this);
                    }
                    catch (Exception e)
                    {                       
                        NotificationService.AddtoLog("Exception", this.Name, e.Message);
                        Action action = new Action(DateTime.Now, "Network Error", 0, HostId);
                        Status = "Network Error";
                        Core.Instance.AddAction(action, HostId);
                        if (Selection)
                            Core.Instance.GetActions(this);
                    }
                }
            }
            else
            {
                Status = "Paused";
            }
        }

        public async void RangeTick()
        {

            try
            {
                Ping ping = new Ping();
                PingReply pingReply = null;
                pingReply = await ping.SendPingAsync(Address, 1);                

                if (pingReply.Status.ToString() == "Success")
                {
                    Status = "Ok";
                   await GetNameOverIp();
                }

                if (pingReply.Status.ToString() != "Success" )
                {
                    counter++;
                    if (counter == 1)
                        RangeTick();
                    else
                        Status = "Error";
                }


            }
            catch (Exception e)
            {
                NotificationService.AddtoLog("Exception", this.Name, e.Message);
            }

        }
    }
}
