export const environment = {
    production: true,

    apiSettings: {
        baseUrl: 'http://localhost:44964/',
        methods: {
            getLots: 'api/auction/getAuctions',
            getLotInformation: '',
            addLot: 'api/auction/addLot',
            getAccountInformation: '',
            logIn: 'api/authentication/login',
            logOut: 'api/authentication/logout',
            register: 'api/Account/Register',
            forgotPassword: 'api/authentication/forgot'
        }
    }
}