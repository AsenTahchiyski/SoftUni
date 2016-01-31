function solve(arr) {
    var baseConsumption = 10;
    var fuelPerKg = 0.01;
    var extraSnowBaseCons = 0.3;
    arr.forEach(function(l) {
        var carData = l.split(' ');
        var make = carData[0];
        var fuelType = carData[1];
        var route = carData[2];
        var luggage = Number(carData[3]);
        var customBaseConsum = baseConsumption * getFuelModifier(fuelType);
        customBaseConsum += (fuelPerKg + luggage) / 100;
        var totalCons = customBaseConsum * getTotalRouteLength(route) / 100;
        var extraSnowConsPer100 = extraSnowBaseCons * customBaseConsum / 100;
        var extraSnowCons = extraSnowConsPer100 * getTotalSnowLength(route);
        var totalFuel = Math.round(totalCons + extraSnowCons);
        console.log(make + ' ' + fuelType + ' ' + route + ' ' + totalFuel);
    });

    function getFuelModifier(fuelType) {
        switch(fuelType) {
            case 'petrol': return 1;
            case 'diesel': return 0.8;
            case 'gas': return 1.2;
        }
    }

    function getTotalRouteLength(route) {
        switch(route) {
            case '1': return 110;
            case '2': return 95;
        }
    }

    function getTotalSnowLength(route) {
        switch(route) {
            case '1': return 10;
            case '2': return 30;
        }
    }
}

var input = ['BMW petrol 1 320.5',
    'Golf petrol 2 150.75',
    'Lada gas 1 202',
    'Mercedes diesel 2 312.54'];
solve(input);