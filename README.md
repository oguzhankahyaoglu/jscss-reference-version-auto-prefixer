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
On your Startup.cs file; 
```
services.AddJsCssVersionAutoPrefixer() 
```
or specifying a versioning function, which would be executed as a singleton function (so it can be something costly :))
```
services.AddJsCssVersionAutoPrefixer(() => Guid.NewGuid().ToString()) 
```
