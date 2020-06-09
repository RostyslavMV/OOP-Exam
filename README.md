# OOP-Exam

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  </head>
  <body>
    <div>
      <h2 style="text-align: center; margin-top: 15px;">Екзаменаційна робота</h2>
      <h3 style="text-align: center;">Студента К-29</h3>
      <h3 style="text-align: center; margin-bottom: 20px;">Мочульського Ростислава</h3>
      <p>Виконані завдання:</p>
      <ul style="margin-top: 5px;">
        <li>Циклічний однозв'язний список</li>
        <li>Червоно-чорне дерево</li>
        <li>В+ дерево</li>
        <li>Хеш таблиця, метод ланцюжків</li>
        <li>Хеш таблиця, відкрита адресація</li>
        <li>Алгоритми сортування</li>
        <li>Контейнер</li>
        <li>Сортування в контейнері</li>
        <li>Множини</li>
      </ul>
      <p>Використані патерни:</p>
      <ul style="margin-top: 5px;">
        <li>Iterator</li>
        <li>Builder</li>
        <li>Strategy</li>
        <li>MVVM</li>
        <li>Observer</li>
      </ul>
    </div>
  </body>
</html>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  </head>
  <body>
    <div>
      <h2 style="text-align: center; margin-top: 15px;">Циклічний однозв'язний список</h2>
      <img style="width: 100%; margin-bottom: 10px;" src="https://media.geeksforgeeks.org/wp-content/uploads/CircularSinglyLinkedList.png" alt="" />
      <p>У вузлах списку можуть зберігатись будь-які об'єкти, використані узагальнені типи (Generic). Для списку використаний патерн <b>Iterator</b>.</p>
      <p>Реалізовані операції:</p>
      <ul style="margin-top: 5px;">
        <li>AddToEnd</li>
        <li>AddToBegin</li>
        <li>AddAfter</li>
        <li>Remove</li>
        <li>Search</li>
      </ul>
    </div>
  </body>
</html>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  </head>
  <body>
    <div>
      <h2 style="text-align: center; margin-top: 15px;">Червоно-чорне дерево</h2>
      <img style="width: 100%; margin-bottom: 10px;" src="https://www.geeksforgeeks.org/wp-content/uploads/RedBlackTree.png" alt="" />
      <p>У вузлах дерева можуть зберігатись будь-які об'єкти, використані узагальнені типи (Generic). Для цього дерева використаний патерн
      <b>Iterator</b>.<p>
      <p>Реалізовані операції:</p>
      <ul style="margin-top: 5px;">
        <li>Add</li>
        <li>Remove</li>
        <li>Search</li>
        <li>ToCollection</li>
      </ul>
    </div>
  </body>
</html>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  </head>
  <body>
    <div>
      <h2 style="text-align: center; margin-top: 15px;">В+ дерево</h2>
      <img
        style="width: 100%; margin-bottom: 10px;"
        src="https://upload.wikimedia.org/wikipedia/commons/thumb/3/37/Bplustree.png/800px-Bplustree.png"
        alt=""
      />
      <p>У вузлах дерева можуть зберігатись ключі та значення будь-яких типів, використані узагальнені типи (Generic). Для цього дерева використані
      патерни
      <b>Iterator</b> та <b>Builder</b>.</p>
      <p>Реалізовані операції:</p>
      <ul style="margin-top: 5px;">
        <li>Add</li>
        <li>AddOrUpdate</li>
        <li>Remove (за ключем)</li>
        <li>Search (за ключем)</li>
        <li>ToDictionary</li>
      </ul>
    </div>
  </body>
</html>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  </head>
  <body>
    <div>
      <h2 style="text-align: center; margin-top: 15px;">Хеш таблиця, метод ланцюжків</h2>
      <img
        style="width: 100%; margin-bottom: 10px;"
        src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/d0/Hash_table_5_0_1_1_1_1_1_LL.svg/1280px-Hash_table_5_0_1_1_1_1_1_LL.svg.png"
        alt=""
      />
      <p>Хеш-таблиця на основі методу ланцюжків. Передбачена можливість опціонального використання <b>2-choice</b> хешування. Можуть зберігатись ключі та
      значення будь-яких типів, використані узагальнені типи (Generic).</p>
      <p>Реалізовані операції:</p>
      <ul style="margin-top: 5px;">
        <li>Add</li>
        <li>Remove</li>
        <li>ToCollection</li>
      </ul>
    </div>
  </body>
</html>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  </head>
  <body>
    <div>
      <h2 style="text-align: center; margin-top: 15px;">Хеш таблиця, відкрита адресація</h2>
      <img
        style="width: 100%; margin-bottom: 10px;"
        src="https://upload.wikimedia.org/wikipedia/commons/thumb/9/90/HASHTB12.svg/1200px-HASHTB12.svg.png"
        alt=""
      />
     <p>Хеш-таблиця на основі відкритої адресації. Варіант перебору - квадратичне зондування. Можуть зберігатись ключі та значення будь-яких типів,
      використані узагальнені типи (Generic).</p>
      <p>Реалізовані операції:</p>
      <ul style="margin-top: 5px;">
        <li>Add</li>
        <li>Remove</li>
        <li>ToCollection</li>
      </ul>
    </div>
  </body>
</html>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  </head>
  <body>
    <div>
      <h2 style="text-align: center; margin-top: 15px;">Алгоритми сортування</h2>
      Сортуватись можуть будь-які типи даних, використані узагальнені типи (Generic).
      <h3>Inserton Sort</h3>
       <img style="width: 100%; margin-bottom: 10px;" src="https://media.geeksforgeeks.org/wp-content/uploads/insertionsort.png" alt="" />
       <h3>Heap Sort</h3>
       <img style="width: 100%; margin-bottom: 10px;" src="https://he-s3.s3.amazonaws.com/media/uploads/c9fa843.png" alt="" />
       <h3>Merge Sort</h3>
       <img style="width: 100%; margin-bottom: 10px;" src="https://media.geeksforgeeks.org/wp-content/cdn-uploads/Merge-Sort-Tutorial.png" alt="" />
       <h3>Radix Sort</h3>
       <img style="width: 100%; margin-bottom: 10px;" src="https://cdn.programiz.com/sites/tutorial2program/files/Radix-sort-0_0.png" alt="" />
      </ul>
    </div>
  </body>
</html>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  </head>
  <body>
    <div>
      <h2 style="text-align: center; margin-top: 15px;">Контейнер</h2>
      <img style="width: 100%; margin-bottom: 10px;" src="https://www.mathworks.com/help/matlab/matlab_prog/mapobj_figure1.png" alt="" />  
      <p> У контейнері можуть зберігатись ключі та значення будь-яких типів, використані узагальнені типи (Generic). Контейнер може бути свторений на
      основі червоно-чорного дерева, В+ дерева, циклічного однозв'язного списку, хеш-таблиць відкритої адресації та хеш-таблиць методу ланцюжків.</p>
      <p>Реалізовані операції:</p>
      <ul style="margin-top: 5px;">
        <li>GetValue</li>
        <li>AddOrUpdate</li>
        <li>RemoveByKey</li>
        <li>GetKeys</li>
        <li>GetValues</li>
        <li>GetSortedValues</li>
        <li>GetSortedValuesNumber (повертає потрібну користувачу частину відсортованих значень)</li>
        <li>ToDictionary</li>
      </ul>
    </div>
  </body>
</html>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  </head>
  <body>
    <div>
      <h2 style="text-align: center; margin-top: 15px;">Множини</h2>
      <img
        style="width: 100%; margin-bottom: 10px;"
        src="https://upload.wikimedia.org/wikipedia/commons/thumb/5/5a/Venn0010.svg/1280px-Venn0010.svg.png"
        alt=""
      />
      <p>У множинах можуть зберігатись значення будь-яких типів, використані узагальнені типи (Generic). Множина може бути свторена на основі
      червоно-чорного дерева, В+ дерева, циклічного однозв'язного списку, хеш-таблиць відкритої адресації та хеш-таблиць методу ланцюжків.</p>
      <p>Реалізовані операції:</p>
      <ul style="margin-top: 5px;">
        <li>Add</li>
        <li>Remove</li>
        <li>UnionWith</li>
        <li>IntersectWith</li>
        <li>ExceptWith</li>
        <li>SymmetricExceptWith</li>
      </ul>
    </div>
  </body>
</html>
