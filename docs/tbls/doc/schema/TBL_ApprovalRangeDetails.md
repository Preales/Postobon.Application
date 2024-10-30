# TBL_ApprovalRangeDetails

## Description

## Columns

| Name | Type | Default | Nullable | Children | Parents | Comment |
| ---- | ---- | ------- | -------- | -------- | ------- | ------- |
| Id | int |  | false |  |  |  |
| NApprovalRangeCode | int |  | false |  | [TBL_ApprovalRange](TBL_ApprovalRange.md) |  |
| NLevelCode | int |  | false |  | [TBL_Level](TBL_Level.md) |  |
| NInitialEffectiveContributionRange | decimal |  | true |  |  |  |
| NFinalEffectiveContributionRange | decimal |  | true |  |  |  |
| NInitialRangePercentageInvestment | numeric |  | true |  |  |  |
| NFinalRangePercentageInvestment | numeric |  | true |  |  |  |
| DCreationDate | datetime |  | true |  |  |  |
| SCreationUser | varchar(300) |  | true |  |  |  |
| DModificationDate | datetime |  | true |  |  |  |
| SModificationUser | varchar(300) |  | true |  |  |  |
| BDeleted | bit |  | false |  |  |  |

## Constraints

| Name | Type | Definition |
| ---- | ---- | ---------- |
| PK_TBL_Approval_Range_Details | PRIMARY KEY | CLUSTERED, unique, part of a PRIMARY KEY constraint, [ Id ] |
| FK_TBL_Approval_Range_Details_TBL_Level | FOREIGN KEY | FOREIGN KEY(NLevelCode) REFERENCES TBL_Level(Id) ON UPDATE NO_ACTION ON DELETE NO_ACTION |
| FK_TBL_Approval_Range_TBL_Approval_Range_Details | FOREIGN KEY | FOREIGN KEY(NApprovalRangeCode) REFERENCES TBL_ApprovalRange(Id) ON UPDATE NO_ACTION ON DELETE NO_ACTION |

## Indexes

| Name | Definition |
| ---- | ---------- |
| PK_TBL_Approval_Range_Details | CLUSTERED, unique, part of a PRIMARY KEY constraint, [ Id ] |

## Relations

![er](TBL_ApprovalRangeDetails.svg)

---

> Generated by [tbls](https://github.com/k1LoW/tbls)