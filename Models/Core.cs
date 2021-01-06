using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using VNM2020.Messaging;
using VNM2020.Services;

namespace VNM2020.Models
{
    public class Core : ObservableObject
    {
        private static Core instance = null;
        [NotMapped]
        public static Core Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Core();
                }
                return instance;
            }
        }
               
        public Category targetCategory;
       
        public DispatcherTimer timer = new DispatcherTimer();
        public Host selected;
        public string tipBox = "";
        public string search;

        public Visibility waitingVisibility = Visibility.Hidden;
       

        public BitmapSource mapImage;
        public ObservableCollection<Action> actions = new ObservableCollection<Action>();
        public ObservableCollection<Host> allHosts = new ObservableCollection<Host>();
        public ObservableCollection<LogMessage> mainLog = new ObservableCollection<LogMessage>();
        public ObservableCollection<Category> categories = new ObservableCollection<Category>();

        public Core()
        {
           
            using (var context = new VNMContext())
            {
                context.Database.EnsureCreated();               
                
                if (context.Globals.Any())
                    GlobalSettings.instance = context.Globals.FirstOrDefault(); 

                categories = new ObservableCollection<Category>(context.Categories.ToList());
                allHosts = new ObservableCollection<Host>(context.Hosts.ToList());               
            }
            foreach (var item in allHosts)
            {
                item.Timecounter = item.Seconds;
                item.Father = allHosts.Where(i => i.HostId == item.FatherId).FirstOrDefault();
                if (item.Status=="Error")
                {
                    item.counter = 4;
                }
            }
            foreach (var item in categories)
            {
                item.Hosts = new ObservableCollection<Host>(allHosts.Where(c => c.CategoryId == item.CategoryId));
                item.HostsView = CollectionViewSource.GetDefaultView(item.Hosts);
                item.HostsView.SortDescriptions.Add(new SortDescription("Status", ListSortDirection.Ascending));
                item.HostsView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                var collectionViewLiveShaping = item.HostsView as ICollectionViewLiveShaping;
                collectionViewLiveShaping.IsLiveSorting = true;
                collectionViewLiveShaping.IsLiveFiltering = true;
            }

            if (GlobalSettings.Instance.ShuffleOnStartUp)
                Shuffle(); 

            TimerStart();            
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < allHosts.Count; i++)
            {
                allHosts[i].Timertick = rnd.Next(allHosts[i].Seconds);
                allHosts[i].Timecounter = allHosts[i].Seconds - allHosts[i].Timertick;
            }            
        }

        async public void UpdateSettings()
        {
            await using (var context = new VNMContext())
            {
                if (await context.Globals.AnyAsync())
                {
                    context.Entry(GlobalSettings.Instance).State = EntityState.Modified;                    
                    await context.SaveChangesAsync();
                    NotificationService.AddtoLog("Done", "Core", "Settings saved");
                }
                else
                {
                    await context.Globals.AddAsync(GlobalSettings.Instance);
                    await context.SaveChangesAsync();
                    NotificationService.AddtoLog("Done", "Core", "Settings saved first time");
                }
            }
        }

        async public void ReloadSettings()
        {
            await using (var context = new VNMContext())
            {
                if (await context.Globals.AnyAsync())
                {
                    await context.Entry(GlobalSettings.Instance).ReloadAsync();
                    NotificationService.AddtoLog("Done", "Core", "Settings updated");
                }                
            }
        }

        async public void UpdateHost(Host host)
        {
            if (host!=null)
            {
                await using (var context = new VNMContext())
                {
                    context.Entry(host).State = EntityState.Modified;
                    await context.SaveChangesAsync();                    
                }               
            }
        }

        async public void UpdateCategory(Category category)
        {
            await using (var context = new VNMContext())
            {
                context.Entry(category).State = EntityState.Modified;
                await context.SaveChangesAsync();
                NotificationService.AddtoLog("Done", category.Name, "Updated");               
            }
        }

        async public void RemoveHost(Host host)
        {
            await using (var context = new VNMContext())
            {
                context.Entry(host).State = EntityState.Deleted;
                var command = await context.Database.ExecuteSqlRawAsync($"DELETE from Actions WHERE HostId = {host.HostId}");
                await context.SaveChangesAsync();
                NotificationService.AddtoLog("Done", host.Name, $"Removed with {command} actions");
            }
        }

        async public void RemoveCategory(Category category)
        {
            await using (var context = new VNMContext())
            {     
                for (int i = 0; i < category.Hosts.Count; i++)
                {
                    RemoveHost(category.Hosts[i]);
                }
                context.Entry(category).State = EntityState.Deleted;
                
                await context.SaveChangesAsync();
                NotificationService.AddtoLog("Done", category.Name, "Removed");

            }
        }

        async public void GetActions(Host host)
        {
            bool result = await Task.Run(() =>
            {
                using (var context = new VNMContext())
                {
                    host.actions = new ObservableCollection<Action>(context.Actions.Where(h => h.HostId == host.HostId).OrderByDescending(m => m.ActionId).Take(200).Reverse().ToList());                    
                    host.SetRate();                    
                    return true;
                }
            }); 
        }

        async public void AddCategory(string catName)
        {
            Category category = new Category { Name = catName};
            await using (var context = new VNMContext())
            {
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();                        
                categories.Add(await context.Categories.OrderBy(i => i.CategoryId).LastAsync());
                categories.Last().Hosts = new ObservableCollection<Host>(allHosts.Where(c => c.CategoryId == categories.Last().CategoryId));
                categories.Last().HostsView = CollectionViewSource.GetDefaultView(categories.Last().Hosts);
                categories.Last().HostsView.SortDescriptions.Add(new SortDescription("Status", ListSortDirection.Ascending));
                categories.Last().HostsView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                var collectionViewLiveShaping = categories.Last().HostsView as ICollectionViewLiveShaping;
                collectionViewLiveShaping.IsLiveSorting = true;
                collectionViewLiveShaping.IsLiveFiltering = true;                
            }
            NotificationService.AddtoLog("Done", catName, "Added");            
        }

        async public void AddHost(Host host,int catId)
        {
            await using (var context = new VNMContext())
            {
                host.CategoryId = catId;
                await context.Hosts.AddAsync(host);
                await context.SaveChangesAsync();
                host = await context.Hosts.OrderBy(i => i.HostId).LastAsync();
                categories.Where(i => i.CategoryId == catId).First().Hosts.Add(host);
                allHosts.Add(host);
            }
            NotificationService.AddtoLog("Done", host.Name, "Added");
        }

        async public void AddRange(IEnumerable<Host> hosts)
        {
            await using (var context = new VNMContext())
            {
                await context.Hosts.AddRangeAsync(hosts);
                await context.SaveChangesAsync();
                hosts = await context.Hosts.OrderByDescending(i => i.HostId).Take(hosts.Count()).Reverse().ToListAsync();
                foreach (var item in hosts)
                {
                    categories.Where(i => i.CategoryId == targetCategory.CategoryId).First().Hosts.Add(item);
                    allHosts.Add(item);
                    NotificationService.AddtoLog("Done", item.Name, "Added"); 
                }
            }
            
        }

        public async void AddAction(Action action, int hostId)
        {
            action.HostId = hostId;                 
            await using (var context = new VNMContext())
            {
                await context.Actions.AddAsync(action);               
                await context.SaveChangesAsync();
            }           
        }

        private void TimerStart()
        {           
            timer.Tick += new EventHandler(TimerUpdate);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();           
        }

        async private void TimerUpdate(object sender, EventArgs e)
        {
            for (int i = 0; i < allHosts.Count; i++)
            {
                await Task.Run(() => {
                    allHosts[i].Tick();
                });                
            }                     
        }

        public async void ClearActions()
        {
            var result = await Task.Run(() =>
            {
                using (var context = new VNMContext())
                {
                    foreach (var item in Core.Instance.allHosts)
                    {
                        var command = context.Database.ExecuteSqlRaw($"DELETE FROM Actions WHERE HostId = {item.HostId} AND ActionId NOT IN(SELECT ActionId FROM(SELECT ActionId FROM Actions WHERE HostId = {item.HostId} ORDER BY ActionId DESC  LIMIT 200))");
                        NotificationService.AddtoLog("Done", item.Name, $"Cleared {command} actions");
                    }

                    context.SaveChangesAsync();
                    return context;
                }
                
            });
            waitingVisibility = Visibility.Hidden;
            Messenger.Default.Send<UIMessage>(new UIMessage { PropName = "WaitingVisibility" });
            GlobalSettings.Instance.Closing = true;

            Application.Current.Shutdown();
        }

    }
}
