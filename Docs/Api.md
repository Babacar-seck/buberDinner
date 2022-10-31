
# Buber Dinner Api

- [Buber Dinner Api](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```js
{
    "firstName" : "Babacar",
    "lastName" : "Seck",
    "email" : "babacarseckdevweb@gmail.com",
    "password" : "test2022",
}
```

#### Register Response

```js
200 Ok
```

```js
{
    "id" : "db895-kdh25-ldojf-2511d",
    "firstName" : "Babacar",
    "lastName" : "Seck",
    "email" : "babacarseckdevweb@gmail.com",
    "password" : "test2022",
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```js
{
    "email" : "babacarseckdevweb@gmail.com",
    "password" : "test2022",
}
```

#### Login Response

```js
{
    "id" : "db895-kdh25-ldojf-2511d",
    "firstName" : "Babacar",
    "lastName" : "Seck",
    "email" : "babacarseckdevweb@gmail.com",
    "token" : "eyJhb...hbbQ",
}
```
