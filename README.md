<div align="center">

![VR GAME · UNITY](https://img.shields.io/badge/VR_GAME_·_UNITY-16213e?style=for-the-badge&labelColor=1a1a2e)

# L O N D O N E

### Прикоснись к игровому миру

VR-проект на Unity: взаимодействие руками, игровые объекты и трёхмерное окружение.

![Unity](https://img.shields.io/badge/Unity-6000.0.43f1-111827?style=flat-square&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-512BD4?style=flat-square)
![XR](https://img.shields.io/badge/XR_Interaction_Toolkit-3.1.1-6366F1?style=flat-square)
![OpenXR](https://img.shields.io/badge/OpenXR-1.14.0-0F766E?style=flat-square)

[О проекте](#о-проекте) · [Механики](#механики) · [Запуск](#запуск) · [Команда](#команда)

</div>

---

## О проекте

**Londone** — игровой VR-прототип, в котором взаимодействие с окружением строится вокруг рук игрока. Репозиторий содержит исходный Unity-проект, сцены, C#-скрипты и ресурсы окружения.

В проекте используются XR Interaction Toolkit, Unity Input System и пакеты OpenXR / Oculus. Готовая сборка пока не опубликована в Releases; для знакомства с проектом потребуется Unity Editor.

## Механики

| Система | Что есть в исходниках |
| :--- | :--- |
| 🖐️ **XR-руки** | Анимация пальцев по действиям Trigger и Grip через Input System. |
| 🚪 **Ворота** | Две створки плавно открываются при попадании объекта с тегом Hands в триггер. |
| 🌿 **Восстановление здоровья** | Скрипт Heal увеличивает HP игрока при контакте руки с объектом. |
| 🌳 **Окружение** | Terrain, деревья, камни, материалы и текстуры для игровых сцен. |

## Технологии

**Unity 6 · C# · XR Interaction Toolkit · OpenXR · Unity Input System**

| Зависимость | Версия |
| :--- | :--- |
| Unity Editor | **6000.0.43f1** |
| XR Interaction Toolkit | 3.1.1 |
| Input System | 1.13.1 |
| OpenXR Plugin | 1.14.0 |
| Oculus XR Plugin | 4.5.0 |
| XR Hands | 1.5.0 |

Точные зависимости находятся в [Packages/manifest.json](Packages/manifest.json), версия редактора — в [ProjectVersion.txt](ProjectSettings/ProjectVersion.txt).

## Запуск

1. Установите **Unity Hub** и **Unity Editor 6000.0.43f1**.
2. Клонируйте репозиторий:

   ```bash
   git clone https://github.com/TAlleks/Londone.git
   ```

3. В Unity Hub выберите **Add → Add project from disk** и укажите папку Londone.
4. Откройте проект и дождитесь импорта ресурсов и восстановления пакетов.
5. Откройте сцену **Assets/Scenes/SampleScene.unity**, указанную в настройках сборки. Дополнительная сцена прототипа находится в **Assets/прототип.unity**.
6. Для VR-проверки подключите гарнитуру и настройте XR-провайдер для выбранной платформы в **Project Settings → XR Plug-in Management**, затем запустите Play Mode.

Привязки ввода и совместимость с конкретной гарнитурой зависят от настроек XR проекта.

## Структура проекта

| Путь | Содержимое |
| :--- | :--- |
| [Assets](Assets) | Игровые ресурсы, скрипты и префабы |
| [Assets/Scenes](Assets/Scenes) | Сцены Unity |
| [Assets/Scripts](Assets/Scripts) | Дополнительные скрипты |
| [Assets/XR](Assets/XR) · [Assets/XRI](Assets/XRI) | Ресурсы и настройки XR |
| [Packages](Packages) | Манифест и зафиксированные версии пакетов |
| [ProjectSettings](ProjectSettings) | Настройки редактора, ввода и сборки |

<details>
<summary><b>Ключевые скрипты</b></summary>

- [AnimatedHandOnInput.cs](Assets/AnimatedHandOnInput.cs) — анимация рук по значениям ввода.
- [Gates.cs](Assets/Gates.cs) — открытие ворот через триггер.
- [Player.cs](Assets/Player.cs) — значение здоровья игрока.
- [Heal.cs](Assets/Heal.cs) — взаимодействие для восстановления здоровья.

</details>

## Команда

Участники, представленные в истории репозитория:

**[TAlleks](https://github.com/TAlleks)** · **[yokominn](https://github.com/yokominn)**

Полный вклад — в [истории изменений](https://github.com/TAlleks/Londone/commits/main/).

---

<div align="center">

**LONDONE** · Unity & XR

[Профиль TAlleks](https://github.com/TAlleks) · [Сообщить о проблеме](https://github.com/TAlleks/Londone/issues)

</div>
