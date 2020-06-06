using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        
        /// <summary>
        /// The DBContext uses the unit of work design patter
        /// </summary>
        /// <param name="restaurant"></param>
        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public void Delete(Restaurant restaurant)
        {

            /* Failed with The object cannot be deleted because it was not found in the ObjectStateManager. :
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            */

            db.Restaurants.Attach(restaurant);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();

             /*
             bool oldValidateOnSaveEnabled = localDb.Configuration.ValidateOnSaveEnabled;

            try
            {
              localDb.Configuration.ValidateOnSaveEnabled = false;

              var customer = new Customer { CustomerId = id };

              localDb.Customers.Attach(customer);
              localDb.Entry(customer).State = EntityState.Deleted;
              localDb.SaveChanges();
            }
            finally
            {
              localDb.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
            }            
             */


        }

        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();

        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //return db.Restaurants.OrderBy( r => r.Name);

            //Linq Syntax:
            return from r in db.Restaurants
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant)
        {

            /*
                //The below will not work for concurrent users and the last one that does the update wins.
                //This can cause user to over wrote another user's changes:
                //The Solution is to implement optimistic concurrncy using the db.Entry and EntityState.

                 var r = Get(restaurant.Id);
                 r.Name = "";
                 db.SaveChanges();
            */


            //Entity Framework implements change tracking:
            //Optimistic concurrency when many users are using the system:
            var entry = db.Entry(restaurant);
            entry.State = System.Data.Entity.EntityState.Modified;

            //Entity Framework will look at all the changes and make the update in one unit or work in a transaction.
            db.SaveChanges();
           
        }
    }
}
