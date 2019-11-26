new Vue({
    el: '#Homepage',
    data: {
        Account_name: ''
    },
    mounted: function() {
        var me = this;
        me.getdata();
    }
    ,
    methods: {
        getdata: function () {
            var me = this;
            
            axios.get('https://localhost:44350/api/Login', {
                headers: { 'authorization': sessionStorage.getItem('Errors stored') }
            })
                .then(function (response) {
                    console.log(response);
                    me.Account_name = response.data;
                }
                    
                   

            ).catch(function (error) {
                console.log(error);
            })
        }
    }
})