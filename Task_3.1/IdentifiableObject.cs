using system


public class IdentifiableObject
{
    private string _identifiers;

    public IdentifiableObject(string[] idents)
    {
        _identifiers = idents;
    }

    public bool AreYou(string id)
    {
        if (_identifiers.Contains(id))
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
            return _identifiers[0];
        }
    }

    public void AddIdentifier(string id)
    {

        _identifiers.Add(id);
    }

    public void RemoveIdentifier(string id)
    {
        _identifiers.Remove(id);
    }

    public void PrivilegeEscalation(string pin)
    {
        if (pin == "1234")
        {
            _identifiers.Add("admin");
        }
        else
        {
            throw new Exception("Invalid pin");
        }
    }

}