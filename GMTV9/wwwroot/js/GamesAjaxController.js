function GamesAjaxController() {
};
//Possible not used now
GamesAjaxController.GetGamesTestData = function (getgamelist) {
    //return $.get('/Controllers/GamesAjaxController/GetGameList',
    //    {
    //        getgamelist: getgamelist
    //    }
    return $.ajax({
        type: "POST",
        url: '@Url.Action("GetGameList", "GamesAjaxController")',
        contentType: "application/json; charset=utf-8", 
        dataType: "json",

    });
};
// above not used
GamesAjaxController.GetAllGamesData = function () {

    return $.ajax({
        type: "POST",
        url: "/GamesAjax/GetGameList",
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: successFunc,
        error: errorFunc
    }).done(function (response) {
        //alert('Finish running Ajax call');
        //console.log(response);
        //var temp = response;
        //var First = temp[0].id
        //$(".game-list").css("border", "1px solid red").append('<div class="game-id">' + response[0].id +" "+ response[0].Title + " " + response[0].Subtitle +'</div>');
    });

    function successFunc(game, status) {
        //alert(data);
        //call another function to construct the display
        //var temp = data;
        //var First = temp[0].id
        //var response = data.length;
        console.log(game);
        //$(".games-list").css("border", "1px solid red");
        //for (var i = 0; i < game.length; i++) {
        //    var title = game[i].Title.trim();

        //    var subtitle = "";
        //    if (game[i].Subtitle == null) {

        //    }
        //    else {
        //        subtitle = game[i].Subtitle.trim();
        //    }
        //    var platform = game[i].Platform.trim();
        //    var year = game[i].Year;


        //$(".games-list").append('<div class="game" id="' + game[i].id + '">');
        //$("#" + game[i].id).append(title.trim());



        //actual code  commented out for later work
        //$(".games-list").append('<tr id=' + game[i].id + '>');
        //$("tr#" + game[i].id).attr('class', "game").append('<td>' + title + '</td>').append('<td>' + subtitle + '</td>').append('<td>' + platform + '</td>').append('<td>' + year + '</td>');




        //$.closest("tr").attr('id', game[i].id);
        //$("#" + game[i].id).append('<td>');
        //$.closest("td").append(title.trim());
        //+game[i].id + " " + game[i].Title + " " + game[i].Subtitle + '</div>').attr('id', game[i].id);
        //}
        //$(".game-list").css("border", "1px solid red").append('<div class="game-id">' + data[0].id + " " + data[0].Title + " " + data[0].Subtitle + '</div>');

        //TEST TABLE CREATION USING DIVS
        //******
        GamesAjaxController.PrintGameListHeading();
        //$(".games-list-div");//.css("border", "1px solid red");
        for (var i = 0; i < game.length; i++) {
            var title = game[i].title.trim();
            var subtitle = "";
            if (!game[i].subtitle) {

            }
            else {
                subtitle = game[i].subtitle.trim();
            }
            var platform = game[i].platform.trim();
            var year = game[i].year;
            var platinum = "";
            if (!game[i].hasPlatinum) {
                platinum = "No";
            }
            else { platinum = "Yes" }
            var trophies = ""
            if (!game[i].hasTrophies) {
                trophies = "No";
            }
            else { trophies = "Yes" }

            //Links variables
            //var urlDetail = '@Html.ActionLink("Details", "Details","Games", new { id = ' + game[i].id + '}, null)';
            //var urlDetail2 = '@Html.ActionLink("Details", "Details", "Games", new { id = 1 }, null)';
            //var testactionurl = '<a href="@Url.Action("Details", "Games")" id="' + game[i].id + '">Link</a>';
            //var testactionurl2 = '<a href="@Html.ActionLink("Details", "Details", new { id = ' + game[i].id + '})">Link</a>';
            var urlDetailBtn = '<a class ="list-button" href="/Games/Details/' + game[i].id + '">Details</a>';
            var urlEditBtn = '<a class ="list-button" href="/Games/Edit/' + game[i].id + '">Edit</a>';
            //@Html.ActionLink("Details", "Details", new { id = item.id })
            //var testonclick = '<input type="button" value="My Button" onclick="location.href='@Url.Action(" Details", "Games", new { id = 1 })'" />

            $(".list-div").append('<div id=' + game[i].id + '>');
            $("#" + game[i].id).addClass("game").append('<div class="position-table-left list-data">' + title + '</div>').append('<div class="position-table-middle list-data">' + subtitle + '</div>').append('<div class="position-table-middle-small list-data">' + platform + '</div>').append('<div class="position-table-middle-small list-data">' + year + '</div>')
                .append('<div class="position-table-middle-small list-data">' + trophies + '</div>').append('<div class="position-table-middle-small list-data">' + platinum + '</div>').append('<div class="position-table-middle-small list-data button-list"><button type="button" class="btn btn-primary ">' + urlDetailBtn + '</button></div>').append('<div class="position-table-middle-small list-data button-list"><button type="button" class="btn btn-warning ">' + urlEditBtn + '</button></div>');
        }

    }

    function errorFunc() {
        alert('error - Games List JS');
    }
};

/* Get and return single game by id*/
GamesAjaxController.getGameDetail = function (id) {
    $.ajax({
        type: "POST",
        url: '//GamesAjax/GetGameDetail/' + id,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(game),
        dataType: "json",
        success: function () { alert('Success'); },
        error: function (xhr, status, error) { alert('Error:'); }
    });
}

GamesAjaxController.SetTest = function (objTest) {
    //console.log(objTest);
    //var objConverted = JSON.stringify(objTest);
    //console.log(objConverted);

    $.ajax({
        type: "POST",
        url: '/GamesAjax/testSendFromClient',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(objTest),
        dataType: "json",
        success: function () { alert('Success'); },
        error: function (xhr, status, error) { alert('Error:'); }
    });
};

GamesAjaxController.PrintGameListHeading = function () {
    $(".list-heading").append('<div class="position-table-heading-left list-data">' + "Title" + '</div>').append('<div class="position-table-heading-middle list-data">' + "Subtitle" + '</div>').append('<div class="position-table-heading-middle-small list-data">' + "Platform" + '</div>').append('<div class="position-table-heading-middle-small list-data">' + "Year" + '</div>')
        .append('<div class="position-table-heading-middle-small list-data">' + "Trophies" + '</div>').append('<div class="position-table-heading-middle-small list-data">' + "Platinum" + '</div>');
};

