export const environment = {
    production: false,

    apiSettings: {
        baseUrl: 'http://localhost:61452/',
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
