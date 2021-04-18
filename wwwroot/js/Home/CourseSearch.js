$(document).ready(function () {
    const searchBar = $(".search-bar");
    const searchInput = $(".search-input");
    const searchIcon = $(".search-icon");
    const closeSearch = $(".close-search");
    let courses = $(".course-container");
    const resultsContainer = $("#results-container");
    const resultsBar = $("#results-bar");
    const searchStatement = $(".search-statement");
    const searchStatementBefore = $(".search-statement-before");
    const endOfSearchResults = $(".end-of-search-results");
    const noSearchResults = $(".no-search-results");
    
    let results = [];
    let typingTimer;
    let doneTypingInterval = 500;
    
    $(searchStatementBefore).click(function(){
        $(searchBar).click();
    });
    
    $(searchBar).click(function(){
        Search().open();
    });
    
    
    //Prepare search bar width
    let width = $(searchBar).parent().width();
    if(width < 760)
        width = width/2;
    else
        width = width/3;
    
    
    
    
    const Search = function(){
        return {
            
            open(){
                searchInput.css({width: width}, 500).focus();
                searchBar.addClass('active-search-bar').removeClass('search-bar');
                searchInput.addClass('active-search-input').removeClass('search-input');
                searchIcon.addClass('active-search-icon').removeClass('search-icon');
                closeSearch.fadeIn(300);
                searchStatementBefore.fadeOut(0);
                searchStatement.fadeIn(1000);
                Search().bindEvents();
            },
            close(){
                searchBar.removeClass('active-search-bar').addClass('search-bar');
                searchInput.removeClass('active-search-input').addClass('search-input').val('').keyup();
                searchIcon.removeClass('active-search-icon').addClass('search-icon');
                searchInput.css({width: 0}, 500);
                closeSearch.fadeOut(300);
                searchStatement.fadeOut(0);
                searchStatementBefore.fadeIn(500);
                $(noSearchResults).fadeOut(500);
                $(endOfSearchResults).fadeOut(500);
            },
            
            bindEvents(){
                closeSearch.click(function () {
                    Search().close();
                });
                
                searchInput.keyup(function(){
                    const query = searchInput.val();
                    if(query.length > 0) {
                        clearTimeout(typingTimer);
                        typingTimer = setTimeout(function(){Search().updateResults(query)}, doneTypingInterval);
                    }
                        
                    else
                        Search().clearResults();
                });

                searchInput.keydown( function(){
                    $(noSearchResults).fadeOut(1);
                    $(endOfSearchResults).fadeOut(1);
                    clearTimeout(typingTimer);
                })
            },
            
            updateResults(query) {

                query = query.toString().toLowerCase().trim().replace('خريف', 'høst').replace('ربيع', 'vår');
                
                $(courses).each(function(i, e){
                    
                    const info = $(e).find(".hidden-course-info");
                    const title = info.attr('courseTitle').toString().toLowerCase();
                    const teacher = info.attr('teacher').toString().toLowerCase();
                    const code = info.attr('courseCode').toString().toLowerCase();
                    const semester = info.attr('semester').toString().toLowerCase();
                    const element = $(e).clone().removeAttr('id');
                    
                    if(query === 'høst' || query === 'vår'){
                        if(semester.includes(query))
                            results.push(element);
                    }
                    else{
                        query = query.replace('høst', 'h').replace('vår', 'v');
                        if(title.includes(query) || teacher.includes(query) || code.includes(query))
                            results.push(element);                      
                    }                    
                    
                    
                    
                        
                    
                });
                
                Search().showResults()
            },
            
            showResults(){
                $(resultsBar).fadeIn(500);
                $(resultsContainer).hide();
                $(resultsContainer).html('');
                $(results).each(function(i,e){
                    $(resultsContainer).append(e);
                });
                $(resultsContainer).fadeIn(500);
                if(results.length <= 0){
                    $(noSearchResults).fadeIn(500);
                    $(endOfSearchResults).fadeOut(1);
                }
                else{
                    $(noSearchResults).fadeOut(1);
                    $(endOfSearchResults).fadeIn(500, function(){
                        //Bind events in another file to could choose courses when this element clicked
                        if($(".select-course").length) // If the page is in Plus Applications
                            ChooseCourses().bindEvents();
                    });
                }
                results = [];
                BindInformationButton();
            },
            
            clearResults(){
                $(resultsBar).fadeOut(500);
                $(resultsContainer).fadeOut(500);
            }

        }
    }
    
    
    
});