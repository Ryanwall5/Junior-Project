using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingAssistant3._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace ShoppingAssistant3._0.Data
{
    public class EfDataRepository : IDataRepository
    {
        private ApplicationDbContext _databaseContext = new ApplicationDbContext();

        public ApplicationDbContext GetContext() { return _databaseContext; }
        public void AddItem(Item item)
        {

            if(item == null)
            {

            }
            else
            {
                Item i = new Item();

                i = item;

                _databaseContext.Items.Add(i);

                _databaseContext.SaveChanges();
            }
            
        }

        public List<Item> GetAllItems()
        {
            return _databaseContext.Items.ToList();
        }

        public List<Store> GetAllStores()
        {
            var stores = _databaseContext.Stores.Include(s => s.Address);
            return stores.ToList();
        }

        public List<Address> GetAllAddresses()
        {
            return _databaseContext.Addresses.ToList();
        }

        public Address GetAddressById(int addressId)
        {
            return _databaseContext.Addresses.Find(addressId);
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return _databaseContext.Users.ToList();
        }

        public void RemoveItemAndShoppingListLink(ItemAndShoppingList iands)
        {
            _databaseContext.Itemsandshoppinglistslink.Remove(iands);
            _databaseContext.SaveChanges();
        }

        // this is a function that should be in a controller or class
        public ItemAndShoppingList LookUpItemAndShoppingListGivenItemIdAndShoppingList(ShoppingList thelist, int theitemid)
        {

            return thelist.ItemsAndLists.FirstOrDefault(i => i.ItemId == theitemid);

        }

        // this is a function that should be in a controller or class
        public bool LookUpShoppingListByName(ApplicationUser user, string slname)
        {
            //if list was not found 
            if (user.ShoppingLists.FirstOrDefault(x => x.Name == slname) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CreateShoppingListForUser(string slname, ApplicationUser user)
        {

            ShoppingList s = new ShoppingList()
            {
                Name = slname,
                Date = DateTime.Now,
                ApplicationUser = user,
                ApplicationUserId = user.Id,
            };

            _databaseContext.ShoppingLists.Add(s);
            _databaseContext.SaveChanges();

            //user.ShoppingLists.Add(s);
            //_databaseContext.SaveChanges();
        }

        public ApplicationUser GetCurrentUser(string userid)
        {
            var user = _databaseContext.Users.Where(u => u.Id == userid).First();

            return user;
        }

        public Item FindItemByNameToLowerCase(string itemname)
        {
            return _databaseContext.Items.FirstOrDefault(x => x.Name.ToLower() == itemname.ToLower());
        }


        //this is a function that should be in a controller or class
        public ShoppingList FindUserShoppingList(ApplicationUser user, int listid)
        {
            return user.ShoppingLists.FirstOrDefault(x => x.Id == listid);
        }

        public void AddItemToItemAndListTable(Item item, ItemAndShoppingList iands)
        {
            item.ItemAndLists.Add(iands);


            _databaseContext.SaveChanges();
        }

        public void AddShoppingListToItemAndListTable(ShoppingList thelist, ItemAndShoppingList iands)
        {
            thelist.ItemsAndLists.Add(iands);

            _databaseContext.SaveChanges();
        }


        public void AddItemToUserRecentlySearched(ApplicationUser user, Item item)
        {

            Item i = new Item();
            i = item;
            user.RecentlySearchedItems.Add(i);
            _databaseContext.SaveChanges();
        }

        public Item GetItem(int itemid)
        {
            return _databaseContext.Items.FirstOrDefault(x => x.Id == itemid);
        }

        public ShoppingList GetShoppingList(int shoppinglistid)
        {
            return _databaseContext.ShoppingLists.FirstOrDefault(x => x.Id == shoppinglistid);
        }


        public List<ShoppingList> GetUsersShoppingList(ApplicationUser user)
        {

            return _databaseContext.ShoppingLists.Where(sl => sl.ApplicationUser.HomeStoreId == user.HomeStoreId).ToList();
        }


        // this is something that could be a function in the class or in a controller action to do this and not in the repository.
        public ItemAndShoppingList LookUpInUsersListToFindAItemThatsAlreadyInIt(ShoppingList list, string itemname)
        {
            return list.ItemsAndLists.FirstOrDefault(x => x.Item.Name == itemname);
        }

        public void AddStore(Store store)
        {
            Store s = new Store();
            s = store;

            _databaseContext.Stores.Add(s);

            _databaseContext.SaveChanges();
        }

        public void AddStore(StoreViewModel storeViewModel)
        {
            Address address = storeViewModel.GetAddress();

            _databaseContext.Addresses.Add(address);
            _databaseContext.SaveChanges();

            int addressId = _databaseContext.Addresses.OrderByDescending(s => s.Id)
                .FirstOrDefault(s =>
                s.Street.Equals(address.Street) &&
                s.City.Equals(address.City) &&
                s.State.Equals(address.State) &&
                s.Zip == address.Zip &&
                s.Longitude.Equals(address.Longitude) &&
                s.Latitude.Equals(address.Latitude)).Id;

            Store store = new Store
            {
                AddressId = addressId,
                Name = storeViewModel.Name,
                EmailAddress = storeViewModel.EmailAddress,
                PhoneNumber = storeViewModel.PhoneNumber
            };
            store.AddressId = addressId;

            _databaseContext.Stores.Add(store);

            _databaseContext.SaveChanges();
        }

        public void EditStore(Store store)
        {
            _databaseContext.Entry(store).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }

        public void EditStore(StoreViewModel store)
        {
            if (store.AddressId == 0)
                store.AddressId = _databaseContext.Stores.AsNoTracking()
                    .FirstOrDefault(m => m.Id == store.Id).AddressId;

            Address address = store.GetAddress();

            Store s = new Store
            {
                Id = store.Id,
                AddressId = store.AddressId,
                Name = store.Name,
                EmailAddress = store.EmailAddress,
                PhoneNumber = store.PhoneNumber
            };

            _databaseContext.Entry(address).State = EntityState.Modified;
            //_databaseContext.SaveChanges();
            _databaseContext.Entry(s).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }

        public Store GetStoreById(int storeid)
        {
            return _databaseContext.Stores.Find(storeid);
        }

        public Store GetStoreByName(string storename)
        {
            return _databaseContext.Stores.FirstOrDefault(s => s.Name == storename);
        }

        public IdentityResult Saveuser(ApplicationUser user, string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_databaseContext));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_databaseContext));

            //if (!roleManager.RoleExists("Admin"))
            //{
            //    var roleresult = roleManager.Create(new IdentityRole("Admin"));
            //}

            ApplicationUser AnotherUser = userManager.FindByName(user.UserName);

            if (AnotherUser == null)
            {


                var passwordhasher = new PasswordHasher();
                var hashed = passwordhasher.HashPassword(password);
                user.PasswordHash = hashed;

                IdentityResult userResult = userManager.Create(user);

                //userresult will return errors if there are some and we could return them if we wanted. and then we could display them. 

                if (userResult.Succeeded)
                {
                    _databaseContext.SaveChangesAsync();
                }

                return userResult;
            }
            return null;
        }

        public bool SaveUser(ApplicationUser user, string password)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_databaseContext));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_databaseContext));

            //if (!roleManager.RoleExists("Admin"))
            //{
            //    var roleresult = roleManager.Create(new IdentityRole("Admin"));
            //}

            ApplicationUser AnotherUser = userManager.FindByName(user.UserName);

            if (AnotherUser == null)
            {


                var passwordhasher = new PasswordHasher();
                var hashed = passwordhasher.HashPassword(password);
                user.PasswordHash = hashed;

                IdentityResult userResult = userManager.Create(user);

                //userresult will return errors if there are some and we could return them if we wanted. and then we could display them. 

                if (userResult.Succeeded)
                {
                    _databaseContext.SaveChangesAsync();
                    return true;
                }

                return false;
                //if (userResult.Succeeded)
                //{
                //    var result = userManager.AddToRole(user.Id, "Admin");
                //}




                //    _databaseContext.Users.Add(user);
                //_databaseContext.SaveChanges();
            }
            return false;
        }

        public void RemoveStore(int storeid)
        {
            Store store = _databaseContext.Stores.Find(storeid);
            _databaseContext.Stores.Remove(store);
            _databaseContext.SaveChanges();
        }



        //---------------------- Sections ----------------------------------------
       public List<Section> GetAllSections()
        {
            return _databaseContext.Sections.ToList();
        }


        public Section GetSectionById(int Id)
        {
            return _databaseContext.Sections.FirstOrDefault(s => s.Id == Id);
        }


        public void AddSection(Section section)
        {
            _databaseContext.Sections.Add(section);
            _databaseContext.SaveChanges();
        }

        public void AddSectionToShelf(Store store, Section newlycreatedsection)
        {
            var map = _databaseContext.Maps.Find(store.StoreMapId);

            map.Shelves.FirstOrDefault(s => s.Name == newlycreatedsection.ShelfName).Sections.Add(newlycreatedsection);
            _databaseContext.SaveChanges();
        }


        //--------------------- End Sections ----------------------------------------

        //---------------------- Shelves ----------------------------------------
        public List<Shelf> GetAllShelves()
        {
            return _databaseContext.Shelves.ToList();
        }


        public Shelf GetShelfById(int Id)
        {
            return _databaseContext.Shelves.FirstOrDefault(s => s.Id == Id);
        }


        public void AddShelf(Shelf shelf)
        {
            _databaseContext.Shelves.Add(shelf);
             _databaseContext.SaveChanges();
        }
        //--------------------- End Shelves ----------------------------------------




        //---------------------- Maps ----------------------------------------

        public void CreateStoreMapWithShelves(StoreMap storemap, int sections, Store store)
        {

            var count = 1;
            for (int i = 0; i < storemap.Aisles - 1; i++)
            {
                Shelf shelf = new Shelf(count.ToString(), sections);
                AddShelf(shelf);
                storemap.Shelves.Add(shelf);
                count++;
            }


            if (storemap.BackWall)
            {
                Shelf shelf = new Shelf("backwall", sections);
                AddShelf(shelf);
                storemap.Shelves.Add(shelf);
            }
            if (storemap.RightSection)
            {
                Shelf shelf = new Shelf("Right", sections);
                AddShelf(shelf);
                storemap.Shelves.Add(shelf);
            }
            if (storemap.LeftSection)
            {
                Shelf shelf = new Shelf("Left", sections);
                AddShelf(shelf);
                storemap.Shelves.Add(shelf);
            }

            _databaseContext.Maps.Add(storemap);
            _databaseContext.SaveChanges();


            store.StoreMap = storemap;
            //store.StoreMapId = storemap.Id;
            _databaseContext.SaveChanges();
        }


        public List<StoreMap> GetAllStoreMaps()
        {
            return _databaseContext.Maps.ToList();
        }


        public StoreMap GetStoreMapById(int Id)
        {
            return _databaseContext.Maps.FirstOrDefault(s => s.Id == Id);
        }

        //--------------------- End Maps ----------------------------------------







        public Tag GetTagById(int tagid)
        {
            return _databaseContext.Tags.Find(tagid);
        }

        public Tag GetTagByName(string tagname)
        {
            return _databaseContext.Tags.FirstOrDefault(t => t.Name.Equals(tagname));
        }

        public void AddTag(Tag tag)
        {
            _databaseContext.Tags.Add(tag);
            _databaseContext.SaveChanges();
        }

        public void EditTag(Tag tag)
        {
            _databaseContext.Entry(tag).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }

        public void RemoveTag(int tagid)
        {
            _databaseContext.Tags.Remove(_databaseContext.Tags.Find(tagid));
            _databaseContext.SaveChanges();
        }

        public void RemoveTag(Tag tag)
        {
            _databaseContext.Tags.Remove(tag);
            _databaseContext.SaveChanges();
        }

        public ItemAndTag GetItemAndTagById(int itemandtagid)
        {
            return _databaseContext.ItemsAndTagsLink.Find(itemandtagid);
        }

        public ItemAndTag GetItemAndTagItemIdAndTagId(int itemid, int tagid)
        {
            return _databaseContext.ItemsAndTagsLink.FirstOrDefault(l => l.ItemId == itemid && l.TagId == tagid);
        }

        public void AddItemAndTag(ItemAndTag itemAndTag)
        {
            _databaseContext.ItemsAndTagsLink.Add(itemAndTag);
            _databaseContext.SaveChanges();
        }

        public void RemoveItemAndTag(int itemandtagid)
        {
            _databaseContext.ItemsAndTagsLink.Remove(GetItemAndTagById(itemandtagid));
            _databaseContext.SaveChanges();
        }

        public void RemoveItemAndTag(ItemAndTag itemAndTag)
        {
            _databaseContext.ItemsAndTagsLink.Remove(itemAndTag);
            
        }


        public StoreMap GetLatestStoreMap()
        {
            //    StoreMap sm = _databaseContext.Maps.Last();
            //    return sm;
            return null;
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }

        public List<Tag> GetAllTags()
        {
            return _databaseContext.Tags.ToList();
        }
    }
}