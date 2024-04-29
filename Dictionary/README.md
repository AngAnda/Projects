# Dictionary Application

## Overview

The Dictionary application is designed as an educational tool to enhance vocabulary through interactive learning. The application is built using Windows Presentation Foundation (WPF) following the Model-View-ViewModel (MVVM) architectural pattern to ensure a clear separation of concerns and improve maintainability. It provides users with a unique learning experience through its distinct modules: Administration, Viewing, and Entertainment (Quiz).

## Modules

### 1. Administration

The Administration module is intended exclusively for administrators. It provides CRUD (Create, Read, Update, Delete) operations for managing the words in the dictionary. This feature allows the administrator to maintain the content and ensure it remains relevant and up-to-date.

**Features:**
- Add new words with their definitions, synonyms, and examples.
- Edit existing words to update their definitions, synonyms, and examples.
- Delete words that are no longer relevant or correct.
- View a list of all words for easy management and review.

![image](https://github.com/AngAnda/Dictionary/assets/61116472/99b12a4e-1256-46eb-b889-2814239e9d83)


### 2. Viewing

The Viewing module is accessible to all users. It allows users to browse through the dictionary and explore the words, their meanings and a representative image for the word.

**Features:**
- Browse words in alphabetical order or through a search function.
- View detailed information about each word including its definition, category or associated image.

![image](https://github.com/AngAnda/Dictionary/assets/61116472/17d9fea1-ac82-46e5-a779-bc39829ab736)


### 3. Entertainment (Quiz)

The Entertainment or Quiz module provides a fun way to learn new vocabulary. The application selects five words at random, and the user must guess the word based on its description or an image.

**Features:**
- Interactive quiz format to test knowledge and retention.
- Hints provided through descriptions or images to aid in guessing the words.
- Score tracking to motivate users and track progress over time.

![image](https://github.com/AngAnda/Dictionary/assets/61116472/341c4c26-7547-4d3c-b793-646ae43f5413)
![image](https://github.com/AngAnda/Dictionary/assets/61116472/7601ff31-53dc-468f-9839-dc2f3ffb4f97)

## Technical Details

The application leverages the Windows Presentation Foundation (WPF) framework, employing the Model-View-ViewModel (MVVM) pattern for a clean separation of the UI from the business logic. Persistence is handled through JSON serialization, allowing for easy data storage and retrieval.

**Key Technologies:**
- **WPF:** Provides a robust framework for building rich desktop applications.
- **MVVM:** Enhances testability and maintainability by separating the application's logic from its presentation.
- **JSON Serialization:** Ensures easy and efficient data storage and management.
- **Repository Pattern:** Provides a mechanism to read data from the JSON file

## Getting Started

To get started with the Dictionary application, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Build the solution to resolve any dependencies.
4. Run the application to start exploring and learning new words.
