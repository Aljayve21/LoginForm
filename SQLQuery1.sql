

select prodID,prod_name, price, size,p.category_ID, c.catName from products p inner join category c on c.category_ID = p.category_ID