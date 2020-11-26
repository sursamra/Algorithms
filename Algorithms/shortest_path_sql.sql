--sqllite
create table edges as
    select 1 as f, 2 as t union all
    select 1 as f, 3 union all
    select 2, 4 union all
    select 3, 4
	
	-- check data
	select * from edges
	-- find shortest path
	with recursive cte as (
      select f, t, 1 as lev, (f || '->' || t) as path
      from edges
      where f = 1
      union all
      select e.f, e.t, lev + 1 , (cte.path || '->' || e.t) as path
      from cte join
           edges e
           on e.f = cte.t
      where lev < 100 or e.t = 4
     )
	 
select cte.*
from cte
where cte.t = 4
order by lev
limit 1