## Code Review of [sdfRenderer.h](https://github.com/qreal/qreal/blob/master/qrgui/plugins/pluginManager/sdfRenderer.h)
##### Если комментарий обрамлен вопросами (вот так ? ... ?), это значит, что я не понял какую-то кострукцию или никогда не встречал такого синтаксиса (т.е. это не замечание) :)

* Во всем файле совершенно отстутствуют комментарии, а там, где они есть, не в oxygen формате
* (28, 29) Файлы локальные, поэтому правильнее было бы писать include`ы в кавычках
  ```cpp
  #include <qrkernel/ids.h>
  #include <qrkernel/settingsManager.h>
  ```
* (41) ? ЧТо такое `Q_OBJECT` ?
* (45) Аргумент в конструктор передается не по ссылке, хотя по идее должен
  ```cpp
  explicit SdfRenderer(const QString path);
  ```
* (66-69) Переменные не в CamelCase формате
  ```cpp
  int first_size_x;
  int first_size_y;
  int current_size_x;
  int current_size_y;
  ```
* (72-74, 78-79) Плохие имена переменных 
  ```cpp
  int i;
  int j;
  int sep;
  ```
  ```cpp
  QString s1;
  QString s2;
  ```
* ? Разве не надо инициализовывать переменные значениями по умолчанию ?
* (92-93) ? Что за const за сигнатурой метода ?
  ```cpp
  bool checkShowConditions(const QDomElement &element, bool isIcon) const;
  bool checkCondition(const QDomElement &condition) const;
  ```
* (100) Имя метода не в CamelCase формате
  ```cpp
  void draw_text(QDomElement &element);
  ```
* (104) Лишний пробел между именем метода и скобкой
  ```cpp
  void point (QDomElement &element);
  ```
* Именна не в CamelCase формате
  ```cpp
  void path_draw(QDomElement &element);
  void stylus_draw(QDomElement &element);
  void curve_draw(QDomElement &element);
  void image_draw(QDomElement &element);
  float x1_def(QDomElement &element);
  float y1_def(QDomElement &element);
  float x2_def(QDomElement &element);
  float y2_def(QDomElement &element);
  float coord_def(QDomElement &element, QString coordName, int current_size, int first_size);
  ```
* (115) Строки в аргументах не по константной ссылке передаются
  ```cpp
  void logger(QString path, QString string);
  ```
* (117-118) Лишний комментарий
  ```cpp
  /// checks that str[i] is not L, C, M or Z
  /// @todo Not so helpful comment
  ```
* (139 - 157) С этим классом вообще что-то странное ,имхо. Во-первых, приватный конструктор, что само по себе не очень     полезно, а во-вторых, мне кажется, этот класс можно было б сделать статическим. Судя по реализации, instance() создает экземпляр объекта для доступа к полям mLoadedIcons и mPreferedSizes, что как бы намекет.  
  ```cpp
  class SdfIconLoader ...
  ```
