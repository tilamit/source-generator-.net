using WebApi.Attributes;
using System.ComponentModel;

namespace WebApi.Models;

public partial class UserProfile
{
    [AutoNotify]
    private string _name = string.Empty;

    [AutoNotify]
    private int _age;
}
