using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rape.Modules.Managers
{
    public static class PickupManager
    {
        public static Pickup[] droppedItems;
        private static Dictionary<string, ItemDataEntry> nameMap = new Dictionary<string, ItemDataEntry>();
        public static Dictionary<int, ItemDataEntry> Items { get { return (Dictionary<int, ItemDataEntry>)itemField.GetValue(LootDatabase.Instance); } }
        private static FieldInfo itemField = typeof(LootDatabase).GetField("items", BindingFlags.Instance | BindingFlags.NonPublic);
    }
}
