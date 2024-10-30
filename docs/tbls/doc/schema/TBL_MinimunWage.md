# TBL_MinimunWage

## Description

## Columns

| Name | Type | Default | Nullable | Children | Parents | Comment |
| ---- | ---- | ------- | -------- | -------- | ------- | ------- |
| Id | int |  | false |  |  |  |
| NYear | int |  | false |  |  |  |
| NSalary | numeric |  | false |  |  |  |
| DCreationDate | datetime |  | false |  |  |  |
| SCreationUser | varchar(300) |  | false |  |  |  |
| DModificationDate | datetime |  | true |  |  |  |
| SModificationUser | varchar(300) |  | true |  |  |  |
| BDeleted | bit |  | false |  |  |  |
| BIsActive | bit |  | false |  |  |  |

## Constraints

| Name | Type | Definition |
| ---- | ---- | ---------- |
| PK_TBL_MinimunWage | PRIMARY KEY | CLUSTERED, unique, part of a PRIMARY KEY constraint, [ Id ] |

## Indexes

| Name | Definition |
| ---- | ---------- |
| PK_TBL_MinimunWage | CLUSTERED, unique, part of a PRIMARY KEY constraint, [ Id ] |

## Relations

![er](TBL_MinimunWage.svg)

---

> Generated by [tbls](https://github.com/k1LoW/tbls)