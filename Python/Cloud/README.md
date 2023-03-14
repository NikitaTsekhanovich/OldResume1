Описание
Программа, которая выполняет создание, загрузку и скачивание файлов/папок, а также выдает данные о файлах, которые хранятся в облаке.

Запуск программы
Запустить main.py. После запуска в консоли появятся сценарии работы программы. Далее по сценарию приведены примеры данных, которые 
нужно ввести.

Проект состоит из:
menu.py - определен токен, ссылка на облако и заголовки. В методе main() можно выбрать облако.

create_folder.py - создает папку в облаке.

upload_file.py - выполняется загрузка файла в облако. Находим ссылку на загрузку через json.

download_file.py - выгрузка файлов из облака в формате zip. Здесь ссылку я получаю через парсинг данных.

get_information.py - выводит информацию о файлах на диске. 

found_file.py - поиск файла в директориях на компьютере. Вспомогательный метод, который проверяет правильность входных данных от пользователя. 

select_contract.py - выводит функционал программы.

split_file.py - вспомогательный метод, который "режет" файл на части. Нужен, чтобы загружать файлы размером более 1 гб.

Папка tests - папка, в которой находятся тесты.

test_create_folder_yandex.py - тестирует в create_folder.py создание папки в облаке yandex.

test_upload_file_yandex.py - тестирует в upload_file.py загрузку файла в облако yandex.

test_download_file_yandex.py - тестирует в download_file.py скачивание файла из облака yandex.

test_create_folder_dropbox.py - тестирует в create_folder.py создание папки в облаке dropbox.

test_upload_file_dropbox.py - тестирует в upload_file.py загрузку файла в облако dropbox.

test_download_file_dropbox.py - тестирует в download_file.py скачивание файла из облака dropbox.