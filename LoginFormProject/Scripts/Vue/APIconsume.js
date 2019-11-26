//import Vue from 'vue';    
new Vue({
    el: '#login-div',
    data: {
        Account_name: '',
        password: '',
        errors: '',
        errors1: {},
        errors2: {},
        error3: {},
        error4: {}

    },
    components: {

    },
    methods: {
        login: function () {
            var me = this;
            axios.post('https://localhost:44350/api/Login', {
              
                    Account_name: me.Account_name,
                    Password: me.password
                
            }).then(function (response) {
                console.log(response);

                if (response.data == "Incorrect Username and password") {
                    
                    me.errors = response.data;
                    sessionStorage.setItem('Errors stored', null);
                }

                else {
                    window.location.href = 'https://localhost:44359/Home/Index';
                    sessionStorage.setItem('Errors stored', response.data);
                }
            })
                .catch(function (error) {
                    console.log(error);
                })
        },
        checkChar: function () {
            var me = this;
            me.error3 = [];
            me.error4 = [];
            
            if (me.password.length < 6 && me.password.length != 0) {
                me.error3.push('Minimum character requirement is 6 ');
            }
            if (me.Account_name.length < 4 && me.Account_name.length != 0) {
                me.error4.push('Minimum character requirement is 4 ');
            }

            else {
                me.login();
            }
        },
        checkForm: function () {
            var me = this;


            me.errors1 = [];
            me.errors2 = [];

            if (!me.Account_name) {
                me.errors1.push('Account name required');
            }
            if (!me.password) {
                me.errors2.push('Password required');
            }
            else
            {
                me.checkChar();
            }


        }
    }

});
  