const config = {
  cognito: {
    identityPoolId: "",
    cognitoDomain: "",
    appId: ""
  }
}

var cognitoApp = {
  auth: {},
  Init: function () {

    var authData = {
      ClientId: config.cognito.appId,
      AppWebDomain: config.cognito.cognitoDomain,
      TokenScopesArray: ['email', 'openid', 'profile'],
      RedirectUriSignIn: 'https://postcore.net/hotel/index.html',
      RedirectUriSignOut: 'https://postcore.net/hotel/index.html',
      UserPoolId: config.cognito.identityPoolId,
      AdvancedSecurityDataCollectionFlag: false,
      Storage: null
    };

    cognitoApp.auth = new AmazonCognitoIdentity.CognitoAuth(authData);
    cognitoApp.auth.userhandler = {
      onSuccess: function (result) {

      },
      onFailure: function (err) {
      }
    };
  }
}