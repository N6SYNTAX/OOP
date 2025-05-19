namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            foreach (string id in idents)
            {
                _identifiers.Add(id.ToLower());
            }

        }

        public bool AreYou(string id)
        {
            if (_identifiers.Contains(id.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string FirstId
        {
            get
            {
                return _identifiers.Count > 0 ? _identifiers[0] : "";
            }
        }

        public void AddIdentifier(string id)
        {

            _identifiers.Add(id.ToLower());
        }

        public void RemoveIdentifier(string id)
        {
            _identifiers.Remove(id.ToLower());
        }

        public void PrivilegeEscalation(string pin)
        {

            string pwd = "8669";
            string tutID = "1-13";

            if (pin == pwd)
            {
                _identifiers[0] = tutID;
            }


        }
    }
}