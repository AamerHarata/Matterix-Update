$(document).ready(function() {
    
    const resultsArea = $("#results");
    let allResults = [];
    let resultsToShow = [];
    const checkInputs = $(".check");
    const searchInput = $("#search-input");
    
    //Modal
    const sharedModal = $("#shared-modal");
    const modalContent = $("#shared-modal-content");
    const modalTitle = $("#shared-modal-title");
    const modalConfirm = $("#shared-modal-btn-yes");
    const modalCancel = $("#shared-modal-btn-no");
    
    let startTimer;



    const invoices = function() {
        return {
            init() {
                const active = $("#active").prop('checked');
                const due = $("#due").prop('checked');
                const dueToday = $("#dueToday").prop('checked');
                const late = $("#late").prop('checked');
                const lateToday = $("#lateToday").prop('checked');
                const everything = $("#everything").prop('checked');
                const query = $(searchInput).val();
                const waitModal = $("#wait-modal");
                
                
                $.ajax({
                    type: 'GET',
                    url: '/Admin/GetInvoicesAsObject',
                    data: {active, due, late, dueToday, lateToday, everything, query},
                    beforeSend: function(){
                        waitModal.modal('show');
                        $(resultsArea).html('');
                    },
                    success: function(response) {
                        console.log(response);
                        waitModal.modal('hide');
                        invoices().prepareResults(response);
                    },
                    error: function(){
                        waitModal.modal('hide');
                    }
                });
            },

            show() {
                $(resultsArea).html('');
                
                
                let buttonsHtml = `<div class="display-4 title-1-5 text-center">Results: ${resultsToShow.length}</div><div class="text-center mt-2"><button id="email-all" class="m-btn m-btn-primary">Email all</button>&nbsp;&nbsp;|&nbsp;&nbsp;<button id="sms-all" class="m-btn m-btn-danger">SMS all</button>`;
                const incrementBtn = `&nbsp;&nbsp;|&nbsp;&nbsp;<button id="increment-all" class="m-btn m-btn-danger">Increment all</button>`;

                if(($("#late").prop('checked') || $("#lateToday").prop('checked')) && !($("#dueToday").prop('checked') || $("#due").prop('checked')) )
                    buttonsHtml+=incrementBtn;
                
                buttonsHtml+=`</div><hr class="matterix-background"/>`;
                
                if(resultsToShow.length > 0)
                    $(resultsArea).append(buttonsHtml);

                const sum = {original: 0, full: 0};
                $(resultsToShow).each(function(i, e){
                    $(resultsArea).append(invoices().invoiceHtml(e));
                    sum.original += e.OriginalAmount;
                    sum.full += e.FullAmount;
                });
                
                $(resultsArea).append(`<div class="text-center display-4 title-1-0 un-select"><code>Sum: ${sum.original} / ${sum.full}</code></div>`);
                    
                
                invoices().bindEvents();
            },

            prepareResults(results) {
                allResults = [];
                resultsToShow = [];
                $(results).each(function(i, e){  
                    allResults.push(new Invoice(e));
                });
                resultsToShow = allResults;
                invoices().show();
                
            },

            invoiceHtml(invoice) {
                let color = invoice.IsPaid? 'white' : 'whitesmoke';
                //ToDo :: Change color upon invoice status
                
                
                    return `<div class='row p-2 direction position-relative' style='background-color: ${color}; width: 75%; border: lightgray solid 1px; border-radius: 0.2rem; margin: 1rem auto;'>
                        <div class="col-md-6">
                            <a class="d-inline-block matterix-color card-link un-select" target="_blank" href='/Admin/userPage/${invoice.User['id']}'><div class="title-1-5">${invoice.User['name']}</div></a>
                            <div class="d-inline-block ml-3 un-select">${invoice.Course}</div>
                            <hr/>
                            <div class="ml-3">
                                <div><a class="card-link text-dark" target="_blank" href="/Invoice/${invoice.Number}"><span class="un-select">${invoice.Type}&nbsp;&nbsp;&nbsp;</span></a><span class="small">${invoice.Number} / ${invoice.CID}</span></div>
                                <div class="title-1-5 un-select">${invoice.OriginalAmount} / ${invoice.FullAmount}</div>
                            </div>
                            ${invoices().incrementsHtml(invoice)}                            
                        </div>
                        
                        <div class="col-md-3 un-select small">
                            <div>Original: <span>${invoice.OriginalDueDate} / ${invoice.OriginalDeadline}</span></div>
                            <div>Current: <span>${invoice.CurrentDueDate} / ${invoice.CurrentDeadline}</span></div>
                            <div class="mt-2">${invoice.Description}</div>
                            
                        </div>
                        
                        <div class="col-md-3 small un-select">
                        <div class="mb-5">Email: ${invoice.LastEmail} / SMS: ${invoice.LastSMS}</div>
                            
                            <div style="position: absolute; bottom: 0; right: 0;">
                                <button invoice-number="${invoice.Number}" class='m-btn m-btn-small m-btn-secondary send-email'>Email</button>
                                <button invoice-number="${invoice.Number}" class='m-btn m-btn-small m-btn-secondary send-sms'>SMS</button>
                                <button  invoice-number="${invoice.Number}" class='m-btn m-btn-small m-btn-danger add-increment'>Increment</button>
                                <button  invoice-number="${invoice.Number}" class='m-btn m-btn-small m-btn-danger add-delay'>Delay</button>
                                <a href="/Invoice/DownloadInvoice?invoiceNumber=${invoice.Number}"><button  invoice-number="${invoice.Number}" class='m-btn m-btn-small m-btn-danger'>Print</button></a>
                            </div>
                        </div>
                    
                    
                    </div>`;
            },

            incrementsHtml(invoice) {
                if(invoice.Increments.length < 1)
                    return '';
                let incrementsList = '';
                $(invoice.Increments).each(function(i, e){
                    const incrementRow = `<p>${e['amount']}&nbsp;&nbsp;&nbsp;${e['dueDate']}&nbsp;&nbsp;&nbsp;${e['deadline']}</p>`;
                    incrementsList+=incrementRow;
                });
                let increments =
                    `<div><div class='text-left pointer p-2' data-toggle='collapse' href='#increments-${invoice.Number}' role='button' aria-expanded='false' aria-controls='$increments-{invoice.Number}'>Increments</div></div>
                    <div class='collapse' id='increments-${invoice.Number}'>
                        <div class='card card-body' style='border: none'>
                        <hr/>
                    
                        ${incrementsList}
                        <div class='p-2'><button class='m-btn m-btn-small m-btn-secondary'>go</button></div>
                        <hr/>
                        </div>
                    </div>`;
                
                increments+='';
                return increments;
            },

            paymentsHtml(invoice) {
                if(invoice.Payments.length < 1)
                    return '';
                let paymentsList = '';
                $(invoice.Payments).each(function(i, e){
                    const paymentsRow = `<p>${e['id']}</p>`;
                    paymentsList+=paymentsRow;
                });
                let payments =
                    `<div><div class='text-left pointer p-2' data-toggle='collapse' href='#payments-${invoice.Number}' role='button' aria-expanded='false' aria-controls='payments-{invoice.Number}'>Payments</div></div>
                    <div class='collapse' id='payments-${invoice.Number}'>
                        <div class='card card-body' style='border: none'>
                        <hr/>
                    
                        ${paymentsList}
                        <div class='p-2'><button class='m-btn m-btn-small m-btn-secondary'>payment go</button></div>
                        <hr/>
                        </div>
                    </div>`;

                payments+='';
                return payments;
            },
            
            sendEmail(invoice){
                alert(invoice.Number)
            },

            bindEvents(){
                //Send email to many at the same time
                $("#email-all").unbind().bind('click', function(){

                    const invoicesNumbers = [];

                    $(allResults).each(function(i, e){
                        invoicesNumbers.push(e.Number)
                    });

                    const content = `<p class="pt-2">Sending Email to ${allResults.length} people</p>`;
                    modalContent.html(content);
                    modalTitle.text(`Email to all results`);

                    $(sharedModal).modal('show');
                    $(modalCancel).unbind().bind('click', function(){
                        sharedModal.modal('hide')
                    });
                    
                    $(modalConfirm).unbind().bind('click', function(){
                        $.ajax({
                            type: "GET",
                            url: "/Admin/SendInvoiceNotifications/",
                            data: {invoices: invoicesNumbers, method: 'Email'},
                            traditional: true,
                            success: function(){
                                RevokeNotifications("Email");
                                sharedModal.modal('hide');
                                invoices().init();
                            },
                            error: function () {
                                alert('error');
                            }

                        })
                    });
                });


                //Increment many at the same time
                $("#increment-all").unbind().bind('click', function(){

                    const invoicesNumbers = [];

                    $(allResults).each(function(i, e){
                        invoicesNumbers.push(e.Number)
                    });

                    const content = `<p class="pt-2">Increment all ${allResults.length} people</p>`;
                    modalContent.html(content);
                    modalTitle.text(`Increment all results`);

                    $(sharedModal).modal('show');
                    $(modalCancel).unbind().bind('click', function(){
                        sharedModal.modal('hide')
                    });

                    $(modalConfirm).unbind().bind('click', function(){
                        $.ajax({
                            type: "GET",
                            url: "/Admin/IncrementMany/",
                            data: {invoicesNumbers: invoicesNumbers},
                            traditional: true,
                            success: function(){
                                RevokeNotifications("Email");
                                sharedModal.modal('hide');
                                invoices().init();
                            },
                            error: function () {
                                alert('error');
                            }

                        })
                    });
                });
                
                
                //Send email btn clicked                
                $(".send-email").unbind().bind('click', function(){
                    const invoiceNumber= parseInt($(this).attr('invoice-number'));
                    const invoice = allResults.find(it=>it.Number === invoiceNumber);
                    
                    const content = `<p class="pt-2">Number: ${invoiceNumber}</p><p>Last Email: ${invoice.LastEmail}</p>`;
                    modalContent.html(content);
                    modalTitle.text(`Email to ${invoice.User['name']}`);
                    
                    $(sharedModal).modal('show');
                    $(modalCancel).unbind().bind('click', function(){
                        sharedModal.modal('hide')
                    });
                    $(modalConfirm).unbind().bind('click', function(){


                        
                        
                        
                        
                        $.ajax({
                            type: "GET",
                            url: "/Admin/SendInvoiceNotifications/",
                            data: {invoices: invoiceNumber, method: 'Email'},
                            success: function(){
                                RevokeNotifications("Email");
                                sharedModal.modal('hide');
                                invoices().init();
                            },
                            error: function () {
                                alert('error');  
                            }
                            
                        })
                    });
                });

                //Send sms btn clicked                
                $(".send-sms").unbind().bind('click', function(){
                    const invoiceNumber = parseInt($(this).attr('invoice-number'));
                    const invoice = allResults.find(it=>it.Number === invoiceNumber);

                    const content = `<p class="pt-2">Number: ${invoiceNumber}</p><p>Last SMS: ${invoice.LastSMS}</p>`;
                    modalContent.html(content);
                    modalTitle.text(`SMS to ${invoice.User['name']}`);
                    
                    $(sharedModal).modal('show');
                    $(modalCancel).unbind().bind('click', function(){
                        sharedModal.modal('hide')
                    });
                    $(modalConfirm).unbind().bind('click', function(){
                        sharedModal.modal('hide');
                        
                        //ToDo :: Send sms to single user
                    });
                });


                //Add increment btn clicked                
                $(".add-increment").unbind().bind('click', function(){
                    const invoiceNumber= parseInt($(this).attr('invoice-number'));
                    const invoice = allResults.find(it=>it.Number === invoiceNumber);

                    const content = `<p class="pt-2">Number: ${invoiceNumber}</p><p>Deadline ${invoice.CurrentDeadline}</p>`;
                    modalContent.html(content);
                    modalTitle.text(`Increment for ${invoice.User['name']}`);

                    $(sharedModal).modal('show');
                    $(modalCancel).unbind().bind('click', function(){
                        sharedModal.modal('hide')
                    });
                    $(modalConfirm).unbind().bind('click', function(){
                        sharedModal.modal('hide');
                        
                        const invoicesNumbers = [invoiceNumber];
                        
                        

                        $.ajax({
                            type: "GET",
                            url: "/Admin/IncrementMany/",
                            data: {invoicesNumbers: invoicesNumbers},
                            traditional: true,
                            success: function(){
                                sharedModal.modal('hide');
                                invoices().init();
                            },
                            error: function () {
                                alert('error');
                            }

                        })
                    });
                });
                
                
                
                //Add delay
                $(".add-delay").unbind().bind('click', function(){
                    const invoiceNumber= parseInt($(this).attr('invoice-number'));
                    const invoice = allResults.find(it=>it.Number === invoiceNumber);

                    const content = `<p class="pt-2">Number: ${invoiceNumber}</p><p>Deadline ${invoice.CurrentDeadline}</p><br/><div class="mb-5"><input id="days" class="form-control w-25 m-auto mb-5" placeholder="Delay days"/></div>`;
                    modalContent.html(content);
                    modalTitle.text(`Increment for ${invoice.User['name']}`);

                    $(sharedModal).modal('show');
                    $(modalCancel).unbind().bind('click', function(){
                        sharedModal.modal('hide')
                    });
                    $(modalConfirm).unbind().bind('click', function(){
                        sharedModal.modal('hide');



                        $.ajax({
                            type: "GET",
                            url: "/Admin/AddInvoiceDelay/",
                            data: {invoiceNumber: invoiceNumber, days: parseInt($("#days").val())},
                            traditional: true,
                            success: function(){
                                sharedModal.modal('hide');
                                invoices().init();
                                RevokeNotifications("Email");
                            },
                            error: function () {
                                alert('error');
                            }

                        })
                    });
                });
                
                
                //Type in input
                $("#search-input").unbind().bind('keyup', function(e){
                    const query = $(this).val();
                    if(!query)
                        resultsToShow = allResults;
                    else {
                        resultsToShow = allResults.filter(
                            x => x.Number.toString().includes(query) ||
                                x.CID.toString().includes(query) ||
                                x.User['name'].toUpperCase().includes(query.toString().toUpperCase()) ||
                                x.User['id'].toUpperCase().includes(query.toString().toUpperCase()) ||
                                x.Course.toUpperCase().includes(query.toString().toUpperCase()) ||
                                x.Type.toUpperCase().includes(query.toString().toUpperCase())
                        );
                    }
                    invoices().show();
                    
                    if(e.keyCode === 13){
                        const query = $(searchInput).val();
                        if(!query)
                            invoices().init();
                        
                        else{
                            
                            const waitModal = $("#wait-modal");

                            $.ajax({
                                type: 'GET',
                                url: '/Admin/GetInvoicesAsObject',
                                data: {query},
                                beforeSend: function(){
                                    waitModal.modal('show');
                                    $(resultsArea).html('');
                                },
                                success: function(response) {
                                    console.log(response);
                                    waitModal.modal('hide');
                                    invoices().prepareResults(response);
                                },
                                error: function(){
                                    waitModal.modal('hide');
                                }
                            });
                        }
                    }
                        

                                      
                })
                
                
                
                
                
                //ToDo :: Bind buttons with classes email sms increment and Ids email-all, sms all
            }
        }
    };
    

    
    startTimer = performance.now();
    
    //Bind check boxes (Here just uncheck unrelated)
    $(checkInputs).unbind().bind('click', function(e){
        
        // const clicked = $(this).find('input');
        const target = $(this).attr('target');
        const checked = $(`#${target}`).prop('checked');
        
        if(checked && (target === 'active' || target === 'everything')){
            $(checkInputs).each(function(i,e){
                $(e).find('input').prop('checked', '');
            });
            $("#"+target).prop('checked', 'checked')
        }
        
        
        if(checked && (target === 'late' || target === 'due')){
            $(checkInputs).each(function(i, e){
                const inputTarget = $(e).attr('target');
                if(inputTarget !== 'late' && inputTarget !== 'due' )
                    $(e).find('input').prop('checked', '');
            })
        }

        if(checked && (target === 'lateToday' || target === 'dueToday')){
            $(checkInputs).each(function(i, e){
                const inputTarget = $(e).attr('target');
                if(inputTarget !== 'lateToday' && inputTarget !== 'dueToday' )
                    $(e).find('input').prop('checked', '');
            })
        }
        
        invoices().init();   
        
    });
    
    
    
    invoices().init();
    
    $("form").submit((e)=>{
        e.preventDefault();
        //ToDo :: update results
    })


});

class Invoice {
    constructor(invoice){
        this.Number = invoice['number'];
        this.User = invoice['user'];
        this.Increments = invoice['increments'];
        this.CID = invoice['cid'];
        this.Course = invoice['course'];
        this.OriginalAmount = invoice['amount'];
        this.OriginalDueDate = invoice['dueDate'];
        this.OriginalDeadline = invoice['deadline'];
        this.CurrentDueDate = invoice['currentDueDate'];
        this.CurrentDeadline = invoice['currentDeadline'];
        this.Type = invoice['type'];
        this.Payments = invoice['payments'];
        this.FullAmount = invoice['fullAmount'];
        this.Description = invoice['description'];
        this.LastEmail = invoice['lastEmail'];
        this.LastSMS = invoice['lastSms'];
        this.IsPaid = invoice['isPaid'];
        
        
    }
    
    Number;
    CID;
    User;
    Increments = [];
    Payments = [];
    Course;
    OriginalAmount;
    FullAmount;
    OriginalDueDate;
    OriginalDeadline;
    CurrentDueDate;
    CurrentDeadline;
    Type;
    Description;
    LastEmail;
    LastSMS;
    IsPaid;
    
    
}