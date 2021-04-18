$(document).ready(function(){

    paypal.Buttons({
        enableStandardCardFields: false,
        payment: function(data, actions) {
            return actions.payment.create({
                payment: {
                    transactions: [
                        {
                            amount: {
                                total: '1000',
                                currency: 'NOK'
                            }
                        }
                    ]
                },
                experience: {
                    input_fields: {
                        no_shipping: 1,
                        address_override: 0,
                    }
                }
            });
        }
    }).render('#paypal-button-container');
    
});