# jscss-reference-version-auto-prefixer
This library enables auto prefixing all script/link tags for javascript/css file references like:
```
<link rel="stylesheet" href="/assets/css/main.css"/>
<script src="/assets/glightbox.min.js"></script>
```
converts these references to:
```
<link rel="stylesheet" href="/assets/css/main.css?v=2019-11-11-00-57-06" />
<script src="/assets/glightbox.min.js?v=2019-11-11-00-57-06"></script>
```

#Usage
Firstly, add following line to _ViewImports.cshtml
```
@addTagHelper *, JsCssReferenceVersionAutoPrefixer
```
On your Startup.cs file; 
```
services.AddJsCssVersionAutoPrefixer() 
```
or specifying a versioning function, which **is goind to be executed for every reference** so keep it cheap in terms of performance :)
```
services.AddJsCssVersionAutoPrefixer(() => Guid.NewGuid().ToString()) 
```
