export const environment = {
    production: true,

    apiSettings: {
        baseUrl: 'http://localhost:44964/',
        methods: {
            getLots: 'api/auction/getAuctions',
            getLotInformation: '',
            getAccountInformation: '',
            logIn: 'api/authentication/login',
            logOut: 'api/authentication/logout',
            register: 'api/authentication/register',
            forgotPassword: 'api/authentication/forgot'
        }
    }
}