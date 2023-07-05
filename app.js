const express = require('express');
const exphbs = require('express-handlebars');

const app = express();

// Cấu hình handlebars template engine
app.engine('hbs', exphbs({ extname: '.hbs' }));
app.set('view engine', 'hbs');

// Cấu hình đường dẫn cho các tài nguyên tĩnh
app.use(express.static('public'));

// Định nghĩa các route
app.get('/', (req, res) => {
  // Truyền dữ liệu mẫu cho handlebars template
  const data = {
    users: [
      { id: 1, name: 'John Doe' },
      { id: 2, name: 'Jane Smith' },
      { id: 3, name: 'Bob Johnson' },
    ],
    resources: [
      { id: 1, name: 'Gold', quantity: 100 },
      { id: 2, name: 'Wood', quantity: 50 },
      { id: 3, name: 'Stone', quantity: 75 },
    ],
  };

  // Render template và trả về kết quả cho client
  res.render('index', data);
});

// Khởi động server
app.listen(3000, () => {
  console.log('Server started on http://localhost:3000');
});
