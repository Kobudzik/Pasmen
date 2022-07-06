using System.Collections.Generic;
using System.Linq;

namespace Pasmen.Common
{
    public enum PasmenMenuActionType
    {
        Add,
        Clear,
        Save,
        ReloadFile,
        Exit
    }

    public static class MenuActionsHelper
    {
        public static Dictionary<PasmenMenuActionType, string> MenuActionMappings = new Dictionary<PasmenMenuActionType, string>()
        {
            {PasmenMenuActionType.Add, "A"},
            {PasmenMenuActionType.Clear, "C"},
            {PasmenMenuActionType.Save, "S"},
            {PasmenMenuActionType.ReloadFile, "R"},
            {PasmenMenuActionType.Exit, "X"},
        };

        public static string GetActionKeyByType(PasmenMenuActionType type)
        {
            return MenuActionMappings[type];
        }

        public static PasmenMenuActionType GetActionTypeByKey(string value)
        {
            return MenuActionMappings.Single(x => value.Equals(x.Value, System.StringComparison.CurrentCultureIgnoreCase)).Key;
        }
    }
}