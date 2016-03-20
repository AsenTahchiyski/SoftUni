(function () {
    function updateTimer() {
        if (!localStorage.pollStartTime) {
            localStorage.pollStartTime = new Date();
        }

        var timeNow = new Date();
        var timeElapsed = ((timeNow - new Date(localStorage.pollStartTime)) / 1000).toFixed();
        var minutesLeft = (4 - timeElapsed / 60).toFixed();
        var secondsLeft = pad((60 - timeElapsed % 60).toFixed());
        var timer = $('#timer');
        if (minutesLeft == 0 && secondsLeft <= 10) {
            timer.css('color', 'red');
            if (minutesLeft == 0 && secondsLeft == 0) {
                clearInterval(quizTimer);
                timer.text('Time\'s up.');
                return;
            }
        }
        timer.text(minutesLeft + ':' + secondsLeft);
    }

    function pad(n) {
        return (n < 10) ? ("0" + n) : n;
    }

    var quizTimer = setInterval(updateTimer, 1000);

    $('#clear').on('click', function () {
        localStorage.pollStartTime = new Date();
        delete localStorage.question1answer;
        delete localStorage.question2answer;
        delete localStorage.question3answer;
        location.reload();
    });

    // radio buttons stuff
    function rememberQuestionAnswerOnClick(questionNum) {
        var selector = 'input[name=\'question' + questionNum + '\']';
        var question = $(selector);
        question.on('click', function () {
            var answerSelector = selector.substring(0, selector.length) + ':checked';
            localStorage['question' + questionNum + 'answer'] = $(answerSelector).val();
        });
    }

    rememberQuestionAnswerOnClick(1);
    rememberQuestionAnswerOnClick(2);
    rememberQuestionAnswerOnClick(3);

    function markChosenAnswersOnReload(questionNum) {
        var selectedAnswer = localStorage['question' + questionNum + 'answer'];
        if (selectedAnswer) {
            var selector = '#q-' + questionNum + '-' + selectedAnswer;
            $(selector).prop('checked', true);
        }
    }

    $(document).ready(function () {
        markChosenAnswersOnReload(1);
        markChosenAnswersOnReload(2);
        markChosenAnswersOnReload(3);
    });

    // submit button actions
    var correctAnswers = 0;
    var totalQuestions = 3;

    function markAnswerCorrectOrNot(questionNum, correct) {
        var choice = localStorage['question' + questionNum + 'answer'];
        var selector = 'label[for=\'q-' + questionNum + '-' + choice + '\']';
        var label = $(selector);
        label.css('font-weight', 'bold');
        if (choice == correct) {
            label.css('color', 'green');
            correctAnswers++;
        } else {
            label.css('color', 'red');
        }
    }

    $('#submit').on('click', function () {
        markAnswerCorrectOrNot(1, 3);
        markAnswerCorrectOrNot(2, 4);
        markAnswerCorrectOrNot(3, 3);
        clearInterval(quizTimer);
        $('#timer').text('All done, you\'ve got ' + correctAnswers + ' out of ' + totalQuestions + ' answers correct.');
    });
})();