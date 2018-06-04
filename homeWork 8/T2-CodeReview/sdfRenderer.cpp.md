## Code Review of [sdfRenderer.cpp](https://github.com/qreal/qreal/blob/master/qrgui/plugins/pluginManager/sdfRenderer.cpp)
##### Если комментарий обрамлен вопросами (вот так ? ... ?), это значит, что я не понял какую-то кострукцию или никогда не встречал такого синтаксиса (т.е. это не замечание) :)

* (27-28) Локальные файлы лучше подключать через кавычки
  ```cpp
  #include <qrutils/imagesCache.h>
  #include <metaMetaModel/elementRepoInterface.h>
  ```
* (60) ? Что значит эта строка ? (т.е. тут побитовое ИЛИ?)
  ```cpp
  if (!file.open(QIODevice::ReadOnly | QIODevice::Text))
  ```
* Этод метод возвращает всегда true (и следующий тоже), мне кажется в том не очень много смысла (но это не точно)
  ```cpp
  bool SdfRenderer::load(const QDomDocument &document)
  {
	  doc = document;
	  const QDomElement docElem = doc.firstChildElement("picture");
	  first_size_x = docElem.attribute("sizex").toInt();
	  first_size_y = docElem.attribute("sizey").toInt();
  
	  return true;
  }
  ```
* Эти строчки копипаст в 3 методах, можно, наверное, вынести их в отдельную функцию 
  ```cpp
  const QDomElement docElem = doc.firstChildElement("picture");
  first_size_x = docElem.attribute("sizex").toInt();
  first_size_y = docElem.attribute("sizey").toInt();
  ```
* (175) Тут правильнее было бы nullptr присваивать
  ```cpp
  this->painter = 0;
  ```
* (125-171)
  1) Можно было бы организовать эти elif`ы в switch
  2) Можно было, наверное, сделать словарь, который по строке возвращает функцию
  3) Там проблемы с пробелами до и после == и переносами скобок
* (202-219) Тут тоже по идее это в свитч можно было написать
* Эти строки повторяются в нескольких методах подряд
  ```cpp
  float x1 = x1_def(element);
	float y1 = y1_def(element);
	float x2 = x2_def(element);
	float y2 = y2_def(element);
  ```
* (315) JUST DO IT! (Лишний коммент)
  ```cpp
  // FIXME: init points array here
  ```
* (350) Тутспробеламичтотонетак) + 0.1 - магическая константа
  ```cpp
  painter->drawLine(QPointF(pointf.x()-0.1, pointf.y()-0.1), QPointF(pointf.x()+0.1, pointf.y()+0.1));
  ```
* (364-400) Мне кажется этот кусок ниже повторяется, но для координаты y (можно вынести в отдельный метод) + последний else не в {}
  ```cpp
  QString xnum = elem.attribute(QString("x").append(str));
		if (xnum.endsWith("%"))
		{
			xnum.chop(1);
			x = current_size_x * xnum.toFloat() / 100 + mStartX;
		}
		else if (xnum.endsWith("a") && mNeedScale)
		{
			xnum.chop(1);
			x = xnum.toFloat() + mStartX;
		}
		else if (xnum.endsWith("a") && !mNeedScale)
		{
			xnum.chop(1);
			x = xnum.toFloat() * current_size_x / first_size_x + mStartX;
		}
		else
			x = xnum.toFloat() * current_size_x / first_size_x + mStartX;
  ```
* (423 и далее)
  1) Тут какая то супер большая вложенность, внешний if можно было бы убрать просто проверкой на null 
    (если null, то сделать то-то)
  2) В самом цикле куча каких-то повторяющихся строк, которые различаются максимум 1 переменной (можно вынести в отдельный метод)
  ```cpp
  void SdfRenderer::path_draw(QDomElement &element) { .. }
  ```
* (565-569) Тут, наверное, else лучше перенести на строчку ниже + лишний пробел между логгером и (
  ```cpp
  } else if (d_cont[i] == 'Z')
			{
				path.closeSubpath();
				logger ("loggerZ.txt", "DONE");
			}
  ```
* (607-608) Тут тоже одно и то же для 2 координат -> можно вынести
	```cpp
	start.setX(elem.attribute("startx").toDouble() * current_size_x / first_size_x);
	start.setY(elem.attribute("starty").toDouble() * current_size_y / first_size_y);
	```
* (658-669) Это тоже можно было в словарь положить
  ```cpp
  if (elem.attribute("stroke-style") == "solid")
				pen.setStyle(Qt::SolidLine);
			if (elem.attribute("stroke-style") == "dot")
				pen.setStyle(Qt::DotLine);
			if (elem.attribute("stroke-style") == "dash")
				pen.setStyle(Qt::DashLine);
			if (elem.attribute("stroke-style") == "dashdot")
				pen.setStyle(Qt::DashDotLine);
			if (elem.attribute("stroke-style") == "dashdotdot")
				pen.setStyle(Qt::DashDotDotLine);
			if (elem.attribute("stroke-style") == "none")
				pen.setStyle(Qt::NoPen);
  ```
* (739-761) Тут elif`ы можно не писать, так все равно в кждой ветве return
* (784-790) Тут сдвинулось) 
  ```cpp
  void SdfRenderer::logger(QString path, QString string)
  {	log.setFileName(path);
	  log.open(QIODevice::Append | QIODevice::Text);
	  logtext.setDevice(&log);
	  logtext << string << "\n";
	  log.close();
  }
  ```
* (799-801) Опять копипастъ
	```cpp
	mRenderer.load(file);
	mRenderer.noScale();
	mSize = QSize(mRenderer.pictureWidth(), mRenderer.pictureHeight());
	```
* (820-821) ? тут я тоже не понимаю, что происходит и почему нет ; ?
  ```cpp
  Q_UNUSED(mode)
	Q_UNUSED(state)
  ```
* (823-827) Названия переменных неоч (меньше 4 символов)
  ```cpp
  int rh = rect.height();
	int rw = rect.width();

	int ph = mRenderer.pictureHeight();
	int pw = mRenderer.pictureWidth();
  ```
* (845-848) Полезно)
	```cpp
	QIconEngine *SdfIconEngineV2::clone() const
	{
		return nullptr;
	}
	```
* Кстати комментов тоже нигде нет, а хотелось хоть какие-нибудь
  
P.S. Мб ревью получилось не очень содержательным, тк довольно сложно понять, что тут происходит(
  
