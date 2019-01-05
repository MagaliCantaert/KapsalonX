import Vue from 'vue';
import VeeValidate from 'vee-validate';
Vue.use(VeeValidate);





//let app = new Vue({
//    el: '#app',
//    data: {
//        BehandelingDames: [
//            { name: 'Knippen', votes: 0 },
//            { name: 'Brushen', votes: 0 },
//            { name: 'Kleuren', votes: 0 }
//        ]
//    }
//})


//var vueDemo = new Vue({
//    el: '#demo',
//    methods: {
//        validateBeforeSubmit() {
//            this.$validator
//                .validateAll()
//                .then(function (response) {
//                    // Validation success if response === true
//                })
//                .catch(function (e) {
//                    // Catch errors
//                })
//        }
//    }
//});






//Vue.use(VeeValidate);

//new Vue({
//    el: '#app',
//    data: function () {
//        return {
//            title: 'Vue Vee Validation',
//            model: {
//                name: '',
//                email: '',
//                bio: '',
//                gender: '',
//                frameworks: [],
//                subscribe: false,
//                languages: [],
//                happy: '',
//                coupon: ''
//            }
//        }
//    },
//    created: function () {
//        VeeValidate.Validator.extend('verify_coupon', {
//            getMessage: (field) => `The ${field} is not a valid coupon.`,
//            validate: (value) => new Promise(resolve => {
//                const validCoupons = ['SUMMER2017', 'WINTER2017', 'FALL2017'];
//                resolve({
//                    valid: value && (validCoupons.indexOf(value.toUpperCase()) > -1)
//                });
//            })
//        });
//    },
//    methods: {
//        onSubmit: function () {
//            this.$validator.validateAll().then(() => {
//                console.log('form is valid', this.model)
//            }).catch(() => {
//                console.log('errors exist', this.errors)
//            });
//        }
//    }
//})