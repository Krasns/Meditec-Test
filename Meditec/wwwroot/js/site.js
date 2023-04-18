$('#CountryName').on('keyup', function () {
    var inputVal = $(this).val();
    $.ajax({
        url: 'https://countriesnow.space/api/v0.1/countries',
        type: 'GET',
        success: function (response) {

            var countryNames = response.data.map(function (country) {
                return {
                    name: country.country,
                    iso2: country.iso2
                };
            });

            var matchingCountries = countryNames.filter(function (countryName) {
                return countryName.name.toLowerCase().indexOf(inputVal.toLowerCase()) !== -1;
            });

            var $countryList = $('#publicHoliday');

            $countryList.empty(); // clear previous search results

            if (matchingCountries.length) {

                var $ul = $('<ul>').addClass('list-group');

                matchingCountries.forEach(function (countryName) {
                    
                    var $li = $('<li>').addClass('list-group-item').text(countryName.name).attr('id', 'li-' + countryName.iso2);
                    var $button = $('<button>').addClass('btn btn-outline-secondary col-md-2').text('Skatīties brīvdienas').attr('id', 'btn-' + countryName.iso2);
                    var $button2 = $('<button>').addClass('btn btn-outline-secondary col-md-2').text('Aukšupielādēt').attr('id', 'Up-' + countryName.iso2);

                    $ul.append($li);
                    $li.append($button);
                    $li.append($button2);

                    $button.on('click', function () {
                        $.ajax({
                            url: 'https://date.nager.at/api/v3/publicholidays/2023/' + countryName.iso2,
                            data: { country: countryName.iso2 },
                            success: function (result) {

                                if (typeof result === 'undefined') {
                                    var $div = $('<div>').addClass('row').empty();
                                    var $h3 = $('<h3>').text('API sarakstā nav šī valsts');
                                    $div.append($h3);
                                    $('#li-' + countryName.iso2).append($div);
                                } else {
                                    var $ul2 = $('<ul>').empty();

                                    result.forEach(function (holiday) {
                                        var $li2 = $('<li>').text(holiday.date + " - " + holiday.name + " - " + holiday.localName);
                                        $ul2.append($li2);
                                    });
                                    $('#li-' + countryName.iso2).append($ul2);
                                }
                            },
                            error: function (xhr, status, error) {
                                console.log('Error:', error);
                            }
                        });
                    });

                    $button2.on('click', function () {
                        $.ajax({
                            url: 'https://localhost:7041/Country/PostPublicHolidays',
                            method: 'POST',
                            data: {
                                //Data to send method
                                Date: countryName.date,
                                LocalName: countryName.localName,
                                Name: countryName.name,
                                CountryCode: countryName.CountryCode,
                                Country: countryName.Country
                            },
                            success: function (response) {
                                // handle successful upload
                                console.log('Data uploaded successfully!');
                            },
                            error: function (xhr, status, error) {
                                // handle error during upload
                                console.log('Error uploading data:', error);
                            }
                        })
                    })

                });
                $countryList.append($ul);
            } else {
                $countryList.text('No matching countries found.');
            }
        }
    });
});