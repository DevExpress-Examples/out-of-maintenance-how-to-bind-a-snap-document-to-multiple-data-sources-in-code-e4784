using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Data;

namespace MultipleDataSources {
    public class Category : XPObject {
        public Category(Session session) : base(session) { }

        public string CategoryName;

        [Association ("Category-Products")]
        public XPCollection<Product> Products
        {
            get { return GetCollection<Product>("Products"); }
        }
    }

    public class Product : XPObject {
        public Product(Session session) : base(session) { }

        public string ProductName;

        [Association("Category-Products")]
        public Category Category;
    }
    #region #CustomXpCollection
    // Implement the IDisplayNameProvider interface to prevent recurring display of the parent object properties.
    public class CustomXPCollection<T> : XPCollection<T>, IDisplayNameProvider {
        public CustomXPCollection(Session session) : base(session) { }

        public string GetDataSourceDisplayName() {
            return typeof(T).Name;
        }
        // Do not create a child node with the name of the property 
        // that is responsible for the "Many" part of the Category-Products relationship.  
        public string GetFieldDisplayName(string[] fieldAccessors) {
            string fieldName = fieldAccessors[fieldAccessors.Length - 1];
            if (fieldName == "Products") return null;
            return fieldName;
        }
    }
    #endregion #CustomXpCollection
}
