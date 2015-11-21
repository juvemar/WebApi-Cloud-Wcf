using System;
using System.IO;
using System.Diagnostics;

using Spring.Social.OAuth1;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.IO;

public class DropboxExample
{
    // Register your own Dropbox app at https://www.dropbox.com/developers/apps
    // with "Full Dropbox" access level and set your app keys and app secret below
    private const string DropboxAppKey = "nwl425ovxbg4f1k";
    private const string DropboxAppSecret = "5bj6itznu3hhlqs";

    private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

    public static void Main()
    {
        DropboxServiceProvider dropboxServiceProvider =
            new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

        // Authenticate the application (if not authenticated) and load the OAuth token
        if (!File.Exists(OAuthTokenFileName))
        {
            AuthorizeAppOAuth(dropboxServiceProvider);
        }
        OAuthToken oauthAccessToken = LoadOAuthToken();

        // Login in Dropbox
        IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

        // Display user name (from his profile)
        DropboxProfile profile = dropbox.GetUserProfileAsync().Result;
        Console.WriteLine("Hi " + profile.DisplayName + "!");

        // Create new folder
        string newFolderName = "FootballPics";
        Entry createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;
        Console.WriteLine("Created folder: {0}", createFolderEntry.Path);

        // Upload a file
        Entry uploadFileEntry1 = dropbox.UploadFileAsync(
            new FileResource("../../Pictures/DelPiero1.jpg"),
            "/" + newFolderName + "/DelPiero1.jpg").Result;
        Console.WriteLine("Uploaded a file: {0}", uploadFileEntry1.Path);

        Entry uploadFileEntry2 = dropbox.UploadFileAsync(
            new FileResource("../../Pictures/DelPiero2.jpg"),
            "/" + newFolderName + "/DelPiero2.jpg").Result;
        Console.WriteLine("Uploaded a file: {0}", uploadFileEntry2.Path);

        Entry uploadFileEntry3 = dropbox.UploadFileAsync(
            new FileResource("../../Pictures/Raul1.jpg"),
            "/" + newFolderName + "/Raul1.jpg").Result;
        Console.WriteLine("Uploaded a file: {0}", uploadFileEntry3.Path);

        Entry uploadFileEntry4 = dropbox.UploadFileAsync(
            new FileResource("../../Pictures/Raul2.jpg"),
            "/" + newFolderName + "/Raul2.jpg").Result;
        Console.WriteLine("Uploaded a file: {0}", uploadFileEntry4.Path);

        // Share a file
        DropboxLink sharedUrl1 = dropbox.GetShareableLinkAsync(uploadFileEntry1.Path).Result;
        Process.Start(sharedUrl1.Url);

        DropboxLink sharedUrl2 = dropbox.GetShareableLinkAsync(uploadFileEntry2.Path).Result;
        Process.Start(sharedUrl2.Url);

        DropboxLink sharedUrl3 = dropbox.GetShareableLinkAsync(uploadFileEntry3.Path).Result;
        Process.Start(sharedUrl3.Url);

        DropboxLink sharedUrl4 = dropbox.GetShareableLinkAsync(uploadFileEntry4.Path).Result;
        Process.Start(sharedUrl4.Url);
    }

    private static OAuthToken LoadOAuthToken()
    {
        string[] lines = File.ReadAllLines(OAuthTokenFileName);
        OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
        return oauthAccessToken;
    }

    private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
    {
        // Authorization without callback url
        Console.Write("Getting request token...");
        OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
        Console.WriteLine("Done.");

        OAuth1Parameters parameters = new OAuth1Parameters();
        string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
            oauthToken.Value, parameters);
        Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
        Process.Start(authenticateUrl);
        Console.Write("Press [Enter] when authorization attempt has succeeded.");
        Console.ReadLine();

        Console.Write("Getting access token...");
        AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
        OAuthToken oauthAccessToken =
            dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
        Console.WriteLine("Done.");

        string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
        File.WriteAllLines(OAuthTokenFileName, oauthData);
    }
}
