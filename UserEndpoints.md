### User Endpoints

## Authorize : `POST /api//user/authenticate/`

# Used to collect a token for a registered user

**URL** : `/api/login/`

**Method** : `POST`

**Auth required** : NO

**Data constraints**

```json
{
    "Username": "[username is plain text]",
    "Password": "[password in plain text]"
}
```

**Data example**

```json
{
    "username": "test@example.com",
    "password": "abcd1234"
}
```

## Success Response

**Code** : `200 OK`

**Content example**

```json
{
    "id": 2,
    "username": "ozgurdurak",
    "firstName": "Özgür",
    "lastName": "Durak",
    "email": "ozgur.durak@yandex.com",
    "token": "someuniquetoken"
}
```

## Error Response

**Condition** : If 'username' and 'password' combination is wrong.

**Code** : `400 BAD REQUEST`

**Content** :

```json
{
     "message": "Username or password is incorrect"
}
```

## Register : `POST /api/user/register/`

# Used to register a user

**URL** : `/api/user/register/`

**Method** : `POST`

**Auth required** : NO

**Data constraints**

```json
{
    "Username": "[Username is plain text]",
    "Password": "[Password in plain text]",
    "Firstname" : "[Firstname is plain text]",
    "Lastname" : "[Lastname is plain text]",
    "Email" : "[Email is plain text]",
    
}
```

**Data example**

```json
{
    "username": "ogunbaysal",
    "password": "abcd1234",
    "Firstname" : "Ogun",
    "Lastname" : "Baysal",
    "Email" : "ogunbaysaltr@gmail.com"
}
```

## Success Response

**Code** : `200 OK`

```

## Error Response

**Condition** : If 'username' is already taken.

**Code** : `400 BAD REQUEST`

**Content** :

```json
{
     "message": "Username \"ozgurdurak1\" is already taken"
}
```