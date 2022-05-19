# Rapport BDD A3 - 2022

_Iman TOURRES, Victor TARROUX, Tom XIE_

## Prévisualisation

## Technologie

### Avalonia

Les trois membres étant sur Linux, WPF n'était pas envisageable car pas disponible sur Linux, on a donc utilisé une dérivé qui est **Avalonia**

###

## Problème rencontrées

### Langage

### Documentation

### Temps

## Requete SQL

***Connaitre la piece la plus vendu, le benefice induit par cette piece et la quantitée moyenne vendu par commandes de cette piece***

```sql
SELECT P.description , sum(OP.quantity), sum(OP.quantity)*P.unit_price, avg(OP.Quantity) FROM ordered_parts OP JOIN parts P ON OP.parts_id=P.id 
JOIN orders O ON OP.orders_id = O.id 
WHERE O.shipping_date>'" + year + "-" + mois + "-01' 
GROUP BY P.id 
HAVING sum(OP.quantity)>= all(SELECT sum(quantity) FROM ordered_parts GROUP BY parts_id);```

***
