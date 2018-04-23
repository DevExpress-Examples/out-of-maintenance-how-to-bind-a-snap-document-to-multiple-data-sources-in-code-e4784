using DevExpress.Xpo;
// ...

namespace Multiple_XPCollection_Datasources {
    public class Category : XPObject {
        string fCategoryName;
        public Category(Session session) : base(session) { }
        
        public string CategoryName {
            get { return fCategoryName; }
            set { SetPropertyValue<string>("CategoryName", ref fCategoryName, value); }
        }        
    }

    public class Product : XPObject {
        string fProductName;
        public Product(Session session) : base(session) {}

        public string ProductName {
            get { return fProductName; }
            set { SetPropertyValue<string>("ProductName", ref fProductName, value); }
        }
    }


}
