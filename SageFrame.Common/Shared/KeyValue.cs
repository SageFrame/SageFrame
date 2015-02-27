#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

public class KeyValue
{
    private string _key;
    private string _value;
    public KeyValue(string key, string value)
    {
        this._key = key;
        this._value = value;
    }

    public string Key { get { return _key; } set { _key = value; } }

    public string Value { get { return _value; } set { _value = value; } }

    public KeyValue()
    {
    }
}