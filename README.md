# Game-2048
В приложении использовалась технология WPF. Приложение представляет собой игру 2048.
Задание:
Игровое поле имеет форму квадрата 4х4. Целью игры
является получение плитки номиналом 2048.
Правила игры
■■ В каждом раунде появляется плитка номиналом 2
(с вероятностью 90%) или 4 (с вероятностью 10%).
■■ Нажатием стрелки игрок может скинуть все плитки
игрового поля в одну из 4-х сторон. Если при сбра-
сывании две плитки одного номинала «налетают»
одна на другую, то они слипаются в одну, номинал
которой равен сумме соединившихся плиток. После
каждого хода на свободной секции поля появляется
новая плитка номиналом 2 или 4. Если при нажатии
кнопки местоположение плиток или их номинал не
изменится, то ход не совершается.
■■ Если в одной строчке или в одном столбце находится
более двух плиток одного номинала, то при сбрасыва-
нии они начинают слипаться с той стороны, в которую
были направлены. Например, находящиеся в одной
строке плитки (4, 4, 4) после хода влево они превра-
тятся в (8, 4), а после хода вправо — в (4, 8).
■■ За каждое соединение игровые очки увеличиваются
на номинал получившейся плитки.
■■ Игра заканчивается поражением, если после очеред-
ного хода невозможно совершить действие.
При разработке приложения необходимо использо-
вать архитектурный шаблон проектирования MVVM.
Задание 2:
Необходимо разработать окно аутентификации поль-
зователя (рис. 2). Для внешнего оформления элементов
управления следует использовать стили и шаблоны эле-
ментов управления. 
===== (Для авторизации "Admin", "Admin".)  =====
