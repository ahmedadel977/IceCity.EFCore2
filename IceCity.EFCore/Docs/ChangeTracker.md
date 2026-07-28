# EF Core Change Tracker

## 1. Tracking

Tracking هو السلوك الافتراضي في EF Core. عند تحميل كيان من قاعدة البيانات، يبدأ EF Core في تتبعه. إذا تم تعديل أي خاصية، يكتشف EF Core التغيير ويحفظه عند استدعاء `SaveChanges()`.

### Example

```csharp
var owner = context.Owners.First();

Console.WriteLine(context.Entry(owner).State);
// Unchanged

owner.FullName = "Ahmed";

Console.WriteLine(context.Entry(owner).State);
// Modified

context.SaveChanges();

Console.WriteLine(context.Entry(owner).State);
// Unchanged
```

---

## 2. No Tracking

يستخدم `AsNoTracking()` عند قراءة البيانات فقط. في هذه الحالة لا يقوم EF Core بتتبع الكيان، مما يحسن الأداء.

### Example

```csharp
var owner = context.Owners
    .AsNoTracking()
    .First();

Console.WriteLine(context.Entry(owner).State);
// Detached
```

---

## 3. Added State

تكون حالة الكيان `Added` بعد إضافته إلى DbContext وقبل حفظه.

### Example

```csharp
var owner = new Owner
{
    FullName = "Ali",
    Email = "ali@gmail.com",
    PhoneNumber = "01011111111"
};

context.Owners.Add(owner);

Console.WriteLine(context.Entry(owner).State);
// Added
```

---

## 4. Modified State

بعد تعديل كيان متتبع، تصبح حالته `Modified`.

### Example

```csharp
owner.FullName = "Ahmed Updated";

Console.WriteLine(context.Entry(owner).State);
// Modified
```

---

## 5. Deleted State

بعد استدعاء `Remove()` تصبح حالة الكيان `Deleted`.

### Example

```csharp
var owner = context.Owners.First();

context.Owners.Remove(owner);

Console.WriteLine(context.Entry(owner).State);
// Deleted
```

---

## 6. Detached State

الكيان غير متتبع بواسطة DbContext، لذلك أي تعديلات عليه لن تُحفظ.

### Example

```csharp
var owner = context.Owners.First();

context.Entry(owner).State = EntityState.Detached;

Console.WriteLine(context.Entry(owner).State);
// Detached
```

---

## 7. Unchanged State

بعد تحميل الكيان من قاعدة البيانات أو بعد تنفيذ `SaveChanges()` تكون حالته `Unchanged`.

### Example

```csharp
var owner = context.Owners.First();

Console.WriteLine(context.Entry(owner).State);
// Unchanged
```