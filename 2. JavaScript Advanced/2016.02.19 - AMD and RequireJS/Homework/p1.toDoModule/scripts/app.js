require.config({
    paths: {
        'Factory': 'factory'
    }
});

require(['factory'], function(Factory) {
    var container = new Factory.Container('Tuesday TODO List');
    var shopping = new Factory.Section('Shopping List');
    var item1 = new Factory.Item('Air-freshener');
    var item2 = new Factory.Item('Pampers');
    var item3 = new Factory.Item('Newspaper');
    var item4 = new Factory.Item('Toilet paper');
    shopping.addItems([item1, item2, item3, item4]);
    container.addSection(shopping);

    var business = new Factory.Section('Business');
    var item5 = new Factory.Item('Inspect fiscal year report');
    var item6 = new Factory.Item('Lunch with board of directors');
    var item7 = new Factory.Item('Fire Jackson');
    var item8 = new Factory.Item('Take a nap');
    var item9 = new Factory.Item('Arrange a meeting with investors');
    business.addItems([item5, item6, item7, item8, item9]);
    container.addSection(business);
    container.addToDOM(document.getElementById('wrapper'));
});
