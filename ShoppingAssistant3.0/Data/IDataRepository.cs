using Microsoft.AspNet.Identity;
using ShoppingAssistant3._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShoppingAssistant3._0.Data
{
    public interface IDataRepository
    {
        ApplicationDbContext GetContext();

        //Item Stuff
        List<Item> GetAllItems();
        void AddItem(Item item);
        Item GetItem(int itemid);   
        Item FindItemByNameToLowerCase(string itemname);

        //Tag stuff
        Tag GetTagById(int tagid);
        Tag GetTagByName(string tagname);
        List<Tag> GetAllTags();
        void AddTag(Tag tag);
        void EditTag(Tag tag);
        void RemoveTag(int tagid);
        void RemoveTag(Tag tag);

        //Tag link stuff
        ItemAndTag GetItemAndTagById(int itemandtagid);
        ItemAndTag GetItemAndTagItemIdAndTagId(int itemid, int tagid);
        void AddItemAndTag(ItemAndTag itemAndTag);
        void RemoveItemAndTag(int itemandtagid);
        void RemoveItemAndTag(ItemAndTag itemAndTag);

        //Address Stuff
        Address GetAddressById(int addressid);
        List<Address> GetAllAddresses();
        //Add the rest later

        //Store stuff
        Store GetStoreByName(string storename);
        Store GetStoreById(int storeid);

    

        void AddStore(Store store);
        void AddStore(StoreViewModel store);
        void EditStore(Store store);
        void EditStore(StoreViewModel store);
        void RemoveStore(int storeid);
        List<Store> GetAllStores();


        //Shopping List stuff
        ShoppingList GetShoppingList(int shoppinglistid);
        ItemAndShoppingList LookUpInUsersListToFindAItemThatsAlreadyInIt(ShoppingList list, string itemname);

        void CreateShoppingListForUser(string slname, ApplicationUser user);

        //User stuff
        List<ApplicationUser> GetAllUsers();
        bool SaveUser(ApplicationUser user, string password);
        IdentityResult Saveuser(ApplicationUser user, string password);
        ApplicationUser GetCurrentUser(string userid);
        void AddItemToUserRecentlySearched(ApplicationUser user, Item item);

        ShoppingList FindUserShoppingList(ApplicationUser user, int listid);

        List<ShoppingList> GetUsersShoppingList(ApplicationUser user);

        bool LookUpShoppingListByName(ApplicationUser user, string slname);

        //Item and Shopping List stuff
        void AddShoppingListToItemAndListTable(ShoppingList thelist, ItemAndShoppingList iands);
        void AddItemToItemAndListTable(Item item, ItemAndShoppingList iands);

        ItemAndShoppingList LookUpItemAndShoppingListGivenItemIdAndShoppingList(ShoppingList thelist, int theitemid);

        void RemoveItemAndShoppingListLink(ItemAndShoppingList iands);

        //Store Map CRUD

        void CreateStoreMapWithShelves(StoreMap storemap, int sections, Store store);

        StoreMap GetLatestStoreMap();

        StoreMap GetStoreMapById(int Id);
        List<StoreMap> GetAllStoreMaps();


        //Section CRUD
        List<Section> GetAllSections();

        Section GetSectionById(int Id);

        void AddSection(Section section);

        void AddSectionToShelf(Store store, Section newlycreatedsection);

        // shelves CRUD

        List<Shelf> GetAllShelves();


        void AddShelf(Shelf shelf);



        


        //Other
        void Dispose();
    }
}
