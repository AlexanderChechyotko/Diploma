export const environment = {
    production: true,

    apiSettings: {
        baseUrl: 'http://localhost:8565/',
        methods: {
            getLots: 'api/auction/getAuctions',
            getLotInformation: '',
            getAccountInformation: '',
            logIn: 'api/authentication/login',
            logOut: 'api/authentication/logout',
            signUp: 'api/authentication/signUp',
            forgotPassword: 'api/authentication/forgot'
        }
    }
}