using System.Text;

var result = Convert.FromBase64String("YWRtaW46YWRtaW4=");
var decode = Encoding.UTF8.GetString(result);
Console.WriteLine(decode);
