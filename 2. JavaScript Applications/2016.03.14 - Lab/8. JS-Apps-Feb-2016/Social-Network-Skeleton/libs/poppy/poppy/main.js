pop('success', 'Great Success!!', 'Borat smiles at you.');
pop('info', 'Information', 'You are on a rock flying through space.');
pop('error', '404', 'Does not compute.');
var callback = function() {
    console.warn('BABOOOOOM!! Kekekeke');
};
pop('warning','Warning', 'Nuclear launch detected.', callback);