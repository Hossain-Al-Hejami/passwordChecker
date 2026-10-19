# Password Checker

A simple password strength checker built with C# and .NET.

I created this project to practise C# programming and learn more about password security.

## Features

- Checks password length
- Detects uppercase and lowercase letters, numbers and special characters
- Checks passwords against a small list of commonly used passwords
- Calculates estimated password entropy
- Rates passwords as weak, medium or strong
- Hides password input using `*` characters

## Technologies

- C#
- .NET
- Regular Expressions (Regex)

## Getting Started

Make sure you have the .NET SDK installed.

Clone the repository:

```bash
git clone https://github.com/Hossain-Al-Hejami/passwordChecker.git
```

Navigate to the project folder:

```bash
cd passwordChecker
```

Run the application:

```bash
dotnet run
```

## Example

```text
=== Password Security Checker ===

Enter password:
****************

Length: 16
Uppercase: yes
Lowercase: yes
Numbers: yes
Special chars: yes
Common password: No
Estimated entropy: 105 bits

Score; 5/5
Result: STRONG
```

## What I Learned

While building this project, I practised:

- Working with methods and return values
- Using loops and conditional statements
- Handling keyboard input
- Using regular expressions to check character types
- Working with arrays and strings
- Calculating a basic password strength score

## Future Improvements

- Improve the password strength calculation
- Expand the list of common passwords
- Add suggestions for improving weak passwords
- Improve input validation

## Note

The password checker uses a basic scoring system. The entropy value is only an estimate based on password length and character types, not a guarantee of actual password security.

---

Developed as a personal C# programming project.
