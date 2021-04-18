/**
 * @return {string}
 */
const CheckVimeo = function (url) {
    
    let temp = url;
    
    
    if (temp.includes('vimeo.com') && !temp.includes('player.vimeo.com/video'))
        temp = temp.replace('vimeo.com', 'player.vimeo.com/video');
    
    return temp;
};

/**
 * @return {string}
 */
const CheckYoutube = function (url){
    
    let temp = url;
    let youtubeVideoId = '';    
    const standardYoutubeTokens = ['', 'http:', 'https:', 'embed', 'youtube', 'youtube.com', 'www.youtube.com', 'youtu.be', 'www.youtu.be'];
    
    if((temp.includes('youtube.com') || temp.includes('youtu.be')) && !temp.includes('embed')){
        
        const tokens = temp.split("/");
        console.log(tokens)
        
        $(tokens).each(function(i, e){
            if(!standardYoutubeTokens.includes(e)){
                console.log('found token: ' + e);
                youtubeVideoId = e;
                if(youtubeVideoId.includes('?v='))
                    youtubeVideoId = youtubeVideoId.split('?v=')[1];
            }
        });
        
    }
    
    if(youtubeVideoId !== '')
        return 'https://www.youtube.com/embed/'+youtubeVideoId;
    else
        return url;

    
};


function VideoProblem(){
    
    const html = '' +
    '<div class="small">' +
        '<div class="mb-2">1- '+JSLanguage("ifQualityIsLow")+'</div>'+
        '<div class="mb-2">2- '+JSLanguage("videoWillBeAvailableSoon")+'</div>'+
        '<div>3- '+JSLanguage("anotherVideoIssues")+'</div>'+
    '</div>';
    
    InformationModal.SetHtml(html);
    InformationModal.Show(JSLanguage('videoProblem'));
    
}