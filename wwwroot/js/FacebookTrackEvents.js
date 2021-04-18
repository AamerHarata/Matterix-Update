const FacebookTrack = function(){
    
    return {

        ViewContent(courseType, courseName){
            fbq('track', 'ViewContent', {
                content_type: courseType,
                content_name: courseName,
            });
        },

        InitiateCheckout(contentCategory, id, contentName, price){
            fbq('track', 'InitiateCheckout', {
                content_category: contentCategory,
                contents: [
                    {
                        id: id,
                        quantity: 1,
                        content_name: contentName,
                    }
                ],

                currency: 'NOK',
                value: parseInt(price)
            });
        },

        Purchase(contentType, id, contentName, price){

            fbq('track', 'Purchase', {
                content_type: contentType,
                content_name: contentName,
                contents: [
                    {
                        id: id,
                        quantity: 1,
                    }
                ],

                currency: 'NOK',
                value: parseInt(price)
            });
            
        },

        CompleteRegistration(contentName) {
            fbq('track', 'CompleteRegistration', {
                
                content_name: contentName,
                status: true,
                currency: 'NOK',
                value: 0
                
                
            });
        }
        
        
        
        
        
    }
    
    
};





$(document).ready(function(){
    
});