using ClassLib;
using CSLabs.Operations;

namespace CSLabs
{
    class Processing : GenericProcessing
    {
        public Processing() : base()
        {
            operations.Add(new Load());
            operations.Add(new Save());
        }
    }
}
