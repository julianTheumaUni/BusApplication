using BusApplication.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BusApplication.ViewModel
{
    public partial class RouteDetailsViewModel : ObservableObject
    {
        public List<Route> routeList;

        public RouteDetailsViewModel()
        {
            routeList = App.RouteRepo.GetAllRoutes();
        }

	public ObservableCollection<RouteCollectionView> RouteCollectionViewItems { get; set; }

	[RelayCommand]
        void AddRoute()
        {
            Debug.WriteLine("Adding from View Model");
            App.RouteRepo.AddRoute(21, "Mushroom Kingdom");
            App.RouteRepo.GetAllRoutes().ForEach(route => { Debug.WriteLine(route.routeNum); });
	          routeList = App.RouteRepo.GetAllRoutes();
        }

	[RelayCommand]
        void GetAllRoutes()
        {
            List<Route> routes = App.RouteRepo.GetAllRoutes();
            routes.ForEach(route => { Debug.WriteLine(route.routeNum); });
        }

	public List<Route> GetRoutes()
        {
            return App.RouteRepo.GetAllRoutes();
        }

	public void SetRouteCollectionView()
        {
            List<Route> routes = GetRoutes();
            List<RouteCollectionView> routeCollection = new List<RouteCollectionView>();
            routes.ForEach(route =>
            {
                int routeNumber = route.routeNum;
                RouteCollectionViewItems.Add(new RouteCollectionView { routeNum = routeNumber});
            });
        }
	
	public Route GetRouteByID(int routeIdIn){
		foreach(Route route in App.RouteRepo.GetAllRoutes()){
			if(route.routeId == routeIdIn){
				return route;
			}
		}
		Route nullRoute = new Route(0, "N/A");
		return nullRoute;
	}
	
    }

    public class RouteCollectionView
    {
        public int routeNum { get; set; }
    }
}
