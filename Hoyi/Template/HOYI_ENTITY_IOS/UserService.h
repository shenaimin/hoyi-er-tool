//
//  <%%# e.ClassName.ToParscal() #%%>Service.h
//  MeetDragonAide
//
//  Created by Ellen on 15/9/22.
//  Copyright (c) 2015年 kuaifish.com. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "<%%# e.ClassName.ToParscal() #%%>.h"
#import "KCSingleton.h"
#import "HTTPREQ.h"


typedef void(^handleBlock)(NSURLResponse *response, NSData *data, NSError *connectionError);

@interface <%%# e.ClassName.ToParscal() #%%>Service : NSObject
singleton_interface(<%%# e.ClassName.ToParscal() #%%>Service)


#define URLString HOSTURL@"<%%# m.Caption #%%>/inter/<%%# e.ClassName.ToParscal() #%%>Service.hoyip"


/**
 是否已创建
 */
-(BOOL)isCreated;

/**
 设置创建状态
 */
-(void)setCreated;



/**
 创建  <%%# e.ClassName.ToParscal() #%%>  表
 */
-(void)createTable;

/**
 删除  <%%# e.ClassName.ToParscal() #%%>  表
 */
-(void)dropTable;



/**
 *  添加 <%%# e.EntityName #%%>
 *
 *  @param <%%# e.ClassName.ToParscal() #%%> <%%# e.EntityName #%%>
 */
-(void)add<%%# e.ClassName.ToParscal() #%%>:(<%%# e.ClassName.ToParscal() #%%> *)<%%# e.ClassName.ToCamel() #%%>;

/**
 *  删除 <%%# e.EntityName #%%>
 *
 *  @param <%%# e.ClassName.ToParscal() #%%> <%%# e.EntityName #%%>
 */
//-(void)remove<%%# e.ClassName.ToParscal() #%%>:(<%%# e.ClassName.ToParscal() #%%> *)<%%# e.ClassName.ToCamel() #%%>;

/**
 *  根据 <%%# e.getfirfield().Comment #%%> 删除 <%%# e.EntityName #%%>
 *
 *  @param <%%# e.getfirfieldName() #%%> <%%# e.getfirfield().Comment #%%>
 */
-(void)remove<%%# e.ClassName.ToParscal() #%%>By<%%# e.getfirfieldName().ToParscal() #%%>:(NSString *)<%%# e.getfirfieldName() #%%>;

/**
 *  根据 <%%# e.getsecfield().Comment #%%> 删除 <%%# e.EntityName #%%>
 *
 *  @param <%%# e.getsecfieldName() #%%> <%%# e.getsecfield().Comment #%%>
 */
-(void)remove<%%# e.ClassName.ToParscal() #%%>By<%%# e.getsecfieldName().ToParscal() #%%>:(NSString *)<%%# e.getsecfieldName() #%%>;

/**
 *  修改 <%%# e.ClassName.ToParscal() #%%>
 *
 *  @param <%%# e.ClassName.ToParscal() #%%> <%%# e.EntityName #%%>
 */
-(void)modify<%%# e.ClassName.ToParscal() #%%>:(<%%# e.ClassName.ToParscal() #%%> *)<%%# e.ClassName.ToCamel() #%%>;

/**
 *  根据 <%%# e.getfirfield().Comment #%%> 取得  <%%# e.EntityName #%%>
 *
 *  @param <%%# e.getfirfieldName().ToParscal() #%%> <%%# e.getfirfield().Comment #%%>
 *
 *  @return <%%# e.EntityName #%%>
 */
-(<%%# e.ClassName.ToParscal() #%%> *)get<%%# e.ClassName.ToParscal() #%%>By<%%# e.getfirfieldName().ToParscal() #%%>:(NSString *)<%%# e.getfirfieldName() #%%>;

/**
 *  根据 <%%# e.getsecfield().Comment #%%> 取得  <%%# e.EntityName #%%>
 *
 *  @param <%%# e.getsecfieldName().ToParscal() #%%> <%%# e.getsecfield().Comment #%%>
 *
 *  @return <%%# e.EntityName #%%>
 */
-(<%%# e.ClassName.ToParscal() #%%> *)get<%%# e.ClassName.ToParscal() #%%>By<%%# e.getsecfieldName().ToParscal() #%%>:(NSString *)<%%# e.getsecfieldName() #%%>;

-(NSArray *)getAll;

-(NSArray *)getAllWithPgIndex:(int)pgIndex pgSize:(int)pgSize;

-(int*)getCount;

-(int*)executeCountwithSql:(NSString*)sql;

-(<%%# e.ClassName.ToParscal() #%%>*)executeEntitywithSql:(NSString*)sql;

-(NSArray *)getEntitieswithSql:(NSString*)sql;

-(void)Post_with:(<%%# e.ClassName.ToParscal() #%%>*)<%%# e.ClassName #%%> behavior:(NSString*)behavior block:(handleBlock)block;

-(NSArray *)Post_getAllWithPgIndex:(int)pgIndex pgSize:(int)pgSize;

-(int*)Post_getCount;

-(NSArray*)transfromdataarray:(NSArray *)rows;


@end
