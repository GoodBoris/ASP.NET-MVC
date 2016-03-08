namespace Service.Utilities.Membership
{
    //Auth type, can be added if we want to add something more
    public enum AuthenticationTypeEnum
    {
        [EnumStringValue("ApplicationCookie")]
        ApplicationCookie = 0,
        //Example additional auth types
        [EnumStringValue("ExternalCookie")]
        ExternalCookie,
        [EnumStringValue("ExternalBearer")]
        ExternalBearer
    }
}